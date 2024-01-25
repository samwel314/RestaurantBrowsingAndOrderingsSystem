using Microsoft.Extensions.Logging.Abstractions;
using RestaurantBrowsingAndOrderingsSystem.Helpers;
using RestaurantSystemModels.Models;

namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class HomeOverview
    {
      public   IEnumerable<RestaurantOverview> Restaurants { get; set; } = null!;

        public PaginationModel Pagination { get; set; } = null!;
    }
}
