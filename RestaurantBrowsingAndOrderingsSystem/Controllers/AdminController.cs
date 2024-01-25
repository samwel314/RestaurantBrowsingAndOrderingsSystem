using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantBrowsingAndOrderingsSystem.Helpers;
using RestaurantBrowsingAndOrderingsSystem.ViewModels;
using RestaurantSystemDataAccess.Services;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.Controllers
{
    // this basic level of authorization by
    // allowing only authenticated users to execute an endpoint.
    [Authorize (policy: "AdminUser")]// ---
    public class AdminController : Controller
    {
        
        private readonly IRestaurantService _restaurantService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IRestaurantService restaurantService, UserManager<ApplicationUser> userManager)
        {
            _restaurantService = restaurantService;
            _userManager = userManager;
        }

        // [AllowAnonymous] // means any one(unauthenticated)
        // can access this endpoint  
        public IActionResult Index()
        {
            var OverView = new SystemOverviewVM
            {
                RestaurantCount = _restaurantService.GetCount(),    

                AdminCount = _userManager.GetUsersForClaimAsync(new Claim (StaticData.UserTypeClaim , StaticData.AdminClaim) ).Result.Count ,

                CustomersCount = _userManager.GetUsersForClaimAsync(new Claim(StaticData.UserTypeClaim, StaticData.CustomerClaim)).Result.Count,
            }; 

            return View(OverView); 
        }  

        public IActionResult UpdateCreate(int ? id  = null)
        {
            if (id == null) 
               return View(new Restaurant());
            // search about this resturant  -- // 

            var model =  _restaurantService.GetRestaurant(id);
            if (model == null)
				return NotFound("This Resource not Found ");

			return View(model);
        }
        [HttpPost]
        public IActionResult UpdateCreate(Restaurant model )
        {
           if (!ModelState.IsValid) 
                return View(model);
            bool Check = false;
            if (model.Id == 0)
                Check = _restaurantService.CreataRestaurant(model);
            else
                Check = _restaurantService.UpdateRestaurant(model); 
               
              if (!Check)
                  return BadRequest("Some Error ...Please Check Your Data");

            
            return RedirectToAction (nameof(Restaurants)) ;
        }

        public IActionResult Restaurants ()
        {
            var model = _restaurantService.GetAll().ToList(); 
            return View(model); 
        }

        public IActionResult Menus (int Id)// Restaurant ->Id
        {
            var model = _restaurantService.GetRestaurant(Id , true );
            if (model == null)
                return NotFound();
      
            return View(model); 
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var flag = _restaurantService.DeleteRestaurant (Id);
            if (flag)
                return Ok();
            else
                return BadRequest();
        }

        public async Task< IActionResult >Users ()
        {
            var Ausers = await _userManager.
               GetUsersForClaimAsync
               (new Claim(StaticData.UserTypeClaim, StaticData.AdminClaim));
         
            var Cusers = await _userManager.
               GetUsersForClaimAsync
              (new Claim(StaticData.UserTypeClaim, StaticData.CustomerClaim));

            var Data = new List<ManageUsersViewModel>
                (Ausers.ToList().Select(u => new ManageUsersViewModel
                {
                    Id = u.Id,
                    UserName = u.FullName,
                    UserEmail = u.Email!,
                    LastSeen = DateTime.Now - u.Lastseen!.Value,
                    CreatedAt = DateTime.Now - u.CreatedAt!.Value,
                    ISLocked = u.LockoutEnd >= DateTime.Now , 
                    UserPhone = u.PhoneNumber ! , 
                    Role = "Admin" 
                }));

            Data.AddRange(Cusers.ToList().Select(u => new ManageUsersViewModel
            {
                Id = u.Id,
                UserName = u.FullName,
                UserEmail = u.Email!,
                LastSeen = DateTime.Now - u.Lastseen!.Value,
                CreatedAt = DateTime.Now - u.CreatedAt!.Value,
                ISLocked = u.LockoutEnd >= DateTime.Now,
                UserPhone = u.PhoneNumber!,
                Role = "Customer"
            }));
            return View(Data); 
        }
        [HttpPost]
        public async  Task<IActionResult> LockUnLock (string Id )
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id); 
            if (user == null)
                return Json(new { success = false, message = "user Not Found  " });

            if (user.LockoutEnd != null &&  user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now; 
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddDays(1);
            }
           await  _userManager.UpdateAsync(user);
            return Json(new { success = true, message = "Done ..  " });
        }
    }
}
