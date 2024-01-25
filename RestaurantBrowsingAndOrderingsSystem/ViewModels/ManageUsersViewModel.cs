namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class ManageUsersViewModel
    {
        public string Id { get; set; } = null!; 
        public string UserName { get; set; } = null!; 
        public string UserEmail { get; set; } = null!;
        public string UserPhone { get; set; } = null!; 
        public TimeSpan CreatedAt { get; set; }
        public TimeSpan LastSeen { get; set; } 
        public string Role { get; set; } = null!;   
        public bool  ISLocked { get; set; } 
    }
}
