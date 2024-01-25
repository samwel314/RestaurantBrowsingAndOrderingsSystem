namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class MenuOverview
    {
        public int Id { get; set; } 
        public string Type { get; set; } = null!;
        public IEnumerable<MealOverview> Meals { get; set; } = null!; 
    }
}
