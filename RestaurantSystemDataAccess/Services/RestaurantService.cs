using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Data;
using RestaurantSystemModels.Models;

namespace RestaurantSystemDataAccess.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext  _context;

        public RestaurantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreataRestaurant(Restaurant model)
        {
            _context.Restaurants.Add(model);    
            var rows = _context.SaveChanges();
            return rows > 0; 
        }

        public bool DeleteRestaurant(int id)
        {
           var model = 
                _context.Restaurants
                .FirstOrDefault(x => x.Id == id);
            if (model == null)
                return false; 
            
            _context.Restaurants.Remove(model);
            _context.SaveChanges(); 
            return true;

        }

        public IQueryable<Restaurant> GetAll()
        {
            return
                _context.Restaurants.AsNoTracking(); 
        }

        public int GetCount()
        {
             return _context.Restaurants.Count();   
        }
        public Restaurant? GetRestaurant(int ? Id , bool include = false)
        {
            if (!include)
                return _context.Restaurants
               .AsNoTracking()
                      .FirstOrDefault(x => x.Id == Id);

            return _context.Restaurants.AsNoTracking().Include(x=>x.Menus)
                !.ThenInclude(m=>m.Meals).FirstOrDefault
                (x => x.Id == Id);    
        }

        public bool UpdateRestaurant(Restaurant model)
        {
            var Data = _context.Restaurants.
                FirstOrDefault(r => r.Id == model.Id);  
            if (Data != null) 
            {
                Data.UpdatedAt = DateTime.UtcNow;
                Data.Name = model.Name; 
                Data.Description = model.Description;   
                Data.Location = model.Location;
                _context.Update(Data); 
                var rows = _context.SaveChanges();
                return rows > 0 ; 
            }

            return false; 
        }
    }
}
