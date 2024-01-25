using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBrowsingAndOrderingsSystem.ViewModels;
using RestaurantSystemDataAccess.Services;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.Controllers
{
    [Authorize(policy: "AdminUser")]
    public class MenuController : Controller
	{
		private readonly IMenuService _menuService;
        private readonly IRestaurantService _restaurantService;

        public MenuController(IMenuService menuService, IRestaurantService restaurantService)
        {
            _menuService = menuService;
            _restaurantService = restaurantService;
        }

        public IActionResult UpdateCreate(int id ,  int ? menuId = null) // menu menuId if we need to Update 
        {
			// means it is create request 
			if (menuId == null )
			{
                var restaurant = _restaurantService.GetRestaurant(id);
                if (restaurant == null)
                    return BadRequest(); 
                return View(new UpdateCreateMenuViewModel()
                {
                    RestaurantName = restaurant.Name,   
                    RestaurantId = restaurant.Id
                }) ;
            }

            //means it is update request 
            var model = _menuService.GetMenu(menuId.Value);
			if ( model == null )	
				return NotFound("This Resource not Found ");

            return View(new UpdateCreateMenuViewModel()
            {
                Description = model.Description,    
                RestaurantName = model.Restaurant.Name,
                RestaurantId = model.RestaurantId ,
                Type = model.Type   ,
                MeneId = model.Id
            });
        }
        [HttpPost]
        public IActionResult UpdateCreate(UpdateCreateMenuViewModel model) 
        {
            if (!ModelState.IsValid)    
                return View(model); 
            bool Check = true;
            var menu = new Menu
            {
                Id = model.MeneId,
                RestaurantId = model.RestaurantId,
                Type = model.Type,
                Description = model.Description,
            };
         
            if (model.MeneId == 0)
            {
                Check = _menuService.CreatMenu(menu);
            }
            else
            {
                Check = _menuService.UpdateMenu(menu);  ; 
            }

            if (!Check)
            {
                ModelState.AddModelError("Type", "This Type Of  Menu Is Used Before ");
                return View(model);
            }

            return RedirectToAction("Menus", "Admin", new { Id = model.RestaurantId }); 
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var flag = _menuService.DeleteMenu(Id);
            if (flag)
                return Ok();
            else
                return BadRequest();
        }
    }
}
