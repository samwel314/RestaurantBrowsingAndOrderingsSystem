using System.ComponentModel.DataAnnotations;

namespace RestaurantSystemModels.Models
{
	public class Meal
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Description { get; set; } = null!;
        public string ? ImageUrl { get; set; } = null!;  
        public double Price { get; set; }
        public double ? Offer {  get; set; }
        public int MenuId { get; set; } 
        public Menu Menu { get; set; } = null!;
    }
}
