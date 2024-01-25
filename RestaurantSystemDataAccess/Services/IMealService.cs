using RestaurantSystemModels.Models;


namespace RestaurantSystemDataAccess.Services
{
    public interface IMealService
    {
        bool CreatMeal(Meal  meal);
        Meal? GetMeal(int id);

        bool UpdateMeal(Meal model);
        Meal DeleteMeal(int id); 

	}

}


