using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantSystemModels.Models;

namespace RestaurantSystemDataAccess.Services
{
    public interface IRestaurantService
    {
        Restaurant? GetRestaurant(int ? Id , bool include = false);
        bool CreataRestaurant(Restaurant model);

        bool UpdateRestaurant(Restaurant model);

        bool DeleteRestaurant(int id);
        IQueryable<Restaurant> GetAll();
        int GetCount();
    }
}
