using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBrowsingAndOrderingsSystem.Helpers;
using RestaurantBrowsingAndOrderingsSystem.ViewModels;
using RestaurantSystemDataAccess.Data;
using RestaurantSystemDataAccess.Services;


namespace RestaurantBrowsingAndOrderingsSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMenuService _menuService; 
        public HomeController(IRestaurantService restaurantService , IMenuService menuService)
        {
            _restaurantService = restaurantService;
            _menuService = menuService;
        }

        public IActionResult Index(int Active =0   )
        {
            // 4 Page size 
            HomeOverview homeOverview = new HomeOverview();
            var DataCount = _restaurantService.GetCount(); 
         
            homeOverview.Pagination = new PaginationModel(DataCount, 4 , Active);
            homeOverview.Restaurants = _restaurantService.GetAll().GetHomeOverView
                ( 4, homeOverview.Pagination.Active); 
           
            return View(homeOverview);
        }
        [Authorize]
        public IActionResult ViewMenu (int MenuId )
        {
            var Menu = _menuService.GetMenu(MenuId, true);  
            return View(Menu);  
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}