using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using RestaurantBrowsingAndOrderingsSystem.Helpers;
using RestaurantBrowsingAndOrderingsSystem.ViewModels;
using RestaurantSystemDataAccess.Services;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.Controllers
{
    [Authorize(policy: "AdminUser")]//
    public class MealController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IMealService _mealService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string _path; 
        public MealController(IMenuService menuService, IMealService mealService, IWebHostEnvironment webHostEnvironment)
        {
            _menuService = menuService;
            _mealService = mealService;
            _webHostEnvironment = webHostEnvironment;
            _path = _webHostEnvironment.WebRootPath; 
        }

        public IActionResult UpdateCreate(int id, int? mealId = null) // menu menuId if we need to Update  // id for menu 
        {
            // means it is create request 
            if (mealId == null)
            {
                var menu = _menuService.GetMenu(id);
                if (menu == null)
                    return BadRequest();
                return View(new UpdateCreateMealViewModel()
                {
                    MenuName = menu.Type,
                    MenuId = menu.Id ,
                    RestaurantId = menu.RestaurantId
                });
            }
            //* ----------  Go tO Servies And Create service for Meal 0.00
            //means it is update request 
            var model = _mealService.GetMeal(mealId.Value);
            if (model == null)
                return NotFound("This Resource not Found ");

            return View(new UpdateCreateMealViewModel()
            {
                MenuName = model.Menu.Type , 
                RestaurantId = model.Menu.RestaurantId,
                MenuId = model.Menu.Id  ,
                MealId = model.Id,
                Name = model.Name , 
                Description = model.Description ,   
                Price = model.Price ,   
                Offer = model.Offer ,   
                ImageUrl = model.ImageUrl ,  
              
            });
        }
        [HttpPost]
        public IActionResult UpdateCreate(UpdateCreateMealViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);
         
            var meal = MapToMeal(model);
            
            // work with file 
            if (model.Image != null )
            {
                var RestaurantDirctory = 
                          Path.Combine(_path,
                       "Restaurant_" + model.RestaurantId.ToString());

                meal.ImageUrl = StaticData.GetSaveGetFileUrl(model.Image, RestaurantDirctory); 
              // if it update req may have old image for meal 
                if (model.ImageUrl!=null)
                {
                    StaticData.DeleteImage(Path.Combine(RestaurantDirctory, model.ImageUrl));
                }
            }

            // Create Request 
            if (meal.Id == 0)
            {
                _mealService.CreatMeal(meal);    
            }
            // Update req 
            else
            {
                if (!_mealService.UpdateMeal(meal))
                    ModelState.AddModelError("", "Some Error In Update Please Try Agine ");
            }
            return RedirectToAction("Menus", "Admin", new { Id = model.RestaurantId });
        }
        [HttpDelete]
		public IActionResult Delete(int Id)
		{
			var model = _mealService.DeleteMeal(Id);
            if (model != null)
            {
                var RestaurantDirctory =
                         Path.Combine(_path,
                      "Restaurant_" + model.Menu.RestaurantId.ToString());

                if (model.ImageUrl != null)
                    StaticData.DeleteImage(Path.Combine(RestaurantDirctory, model.ImageUrl));

                return Ok(); 
            }
            else
                return BadRequest();
		}
		private Meal MapToMeal(UpdateCreateMealViewModel model )
        {
            return new Meal()
            {
                Id = model.MealId,
                MenuId = model.MenuId, // fk > menu Pk  
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Offer = model.Offer,
                ImageUrl = model.ImageUrl,  
            };
        }
    }
}
