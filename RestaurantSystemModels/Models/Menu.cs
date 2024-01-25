using System.ComponentModel.DataAnnotations;

namespace RestaurantSystemModels.Models
{
	public class Menu
    {
        public int Id { get; set; } 
        public int RestaurantId { get; set; } 
        [StringLength(50)]  
        public string Type { get; set; } = null!;
        [StringLength(100)]
        public string Description { get; set; } = null!;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        // nav 
      
        public Restaurant Restaurant { get; set; } = null!;
        
        public IEnumerable<Meal> Meals { get; set; } = null!;
    }
}
