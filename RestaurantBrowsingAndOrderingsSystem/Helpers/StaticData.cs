using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestaurantBrowsingAndOrderingsSystem.ViewModels;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.Helpers
{
    public static class StaticData
    {
        // To Work with Plocicy
        public static readonly string AdminClaim = "Admin";
        public static readonly string CustomerClaim = "Customer";
        public static readonly string UserTypeClaim = "UserType";   

        // --- Load Menu Types 
        public static IEnumerable<SelectListItem> LoadMenuTypes ()
        {
            return new List<SelectListItem> ()
            {
                new SelectListItem()
                {
                    Value = "Beverage" ,
                    Text = "Beverage Menu"
                },
                 new SelectListItem()
                 {
                    Value = "Dessert" ,
                    Text = "Dessert Menu"
                 },

                  new SelectListItem()
                  {
                    Value = "Vegan" ,
                    Text = "Vegan Menu"
                  }
            };
        }

        public static  string GetSaveGetFileUrl(IFormFile file, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filename = Guid.NewGuid().ToString() +
                   Path.GetExtension(file.FileName);

            var finalpath = Path.Combine(path, filename);

            using FileStream stream
                = new FileStream(finalpath, FileMode.Create);

            file.CopyTo(stream);

            return filename;
        }
        

        public static void DeleteImage (string Path )
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);  
            }
        }

        public static List<RestaurantOverview> 
            GetHomeOverView (this IQueryable<Restaurant> restaurants , int pageSize, int Active)
        {
            return restaurants.Select (r => new RestaurantOverview
            {
                Id = r.Id,  
                Name = r.Name,  
                Location = r.Location,  
                Menus = r.Menus!.Select (m=>new MenuOverview
                {
                    Id = m.Id,  
                    Type = m.Type,
                    Meals = m.Meals.Select(m => new MealOverview
                    {
                        ImageUrl = m.ImageUrl! ,
                        Name = m.Name,  
                        Price = m.Price,    
                    }).Take(4).ToList()!,    
                }).ToList()!
            } 
            ).Skip(pageSize * Active).Take(pageSize ).ToList ();
        }
    }

}
