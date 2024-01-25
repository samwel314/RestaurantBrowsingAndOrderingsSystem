using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Data;
using RestaurantSystemModels.Models;


namespace RestaurantSystemDataAccess.Services
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreatMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            var raws = _context.SaveChanges();
            return raws > 0;
        }

        public Meal? GetMeal(int id)
        {
            return
               _context.Meals.Include(m=>m.Menu).
               AsNoTracking().
               FirstOrDefault(m => m.Id == id);       
                         
        }
        //* *Done **
        // Work in it soon !!
        // *be sure you work with image(meal?????) in Good Way 
        public bool UpdateMeal(Meal model)
        {
            // i check her for menu because if any Problem in routing Url ex : /1/2
            var meal = _context.Meals.FirstOrDefault
                (m=>m.Id ==  model.Id  && m.MenuId == model.MenuId) ;
            if (meal == null)
                return false; 
            meal.Name = model.Name; 
            meal.Description = model.Description;   
            meal.Price = model.Price;   
            meal.Offer = model.Offer;   
            meal.ImageUrl = model.ImageUrl;
           
            _context.Meals.Update(meal);
            var raws = _context.SaveChanges();
            return raws > 0;
        }

		public Meal DeleteMeal(int id)
		{
			var model =
				 _context.Meals.Include(m=>m.Menu)
				 .FirstOrDefault(x => x.Id == id);
			if (model == null)
				return null!;

			_context.Meals.Remove(model);
			_context.SaveChanges();
			return model;

		}
	}


}
