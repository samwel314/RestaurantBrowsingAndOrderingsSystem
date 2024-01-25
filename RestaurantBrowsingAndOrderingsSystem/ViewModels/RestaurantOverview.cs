namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class RestaurantOverview
    {
        public int Id { get; set; }
        public string Name { set; get; } = null!;
        public string Location { get; set; } = null!;
        public IEnumerable<MenuOverview> Menus  { get; set; } = null!;
    }
}
