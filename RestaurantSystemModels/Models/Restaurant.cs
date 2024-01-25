using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystemModels.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Restaurant Name")]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "Enter Description For This Restaurant ")]
        public string Description { get; set; } = null!;
        [StringLength(50)]
        [Required(ErrorMessage = "Enter Location For This Restaurant ")]
        public string Location {  get; set; } = null!;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public IEnumerable<Menu> ?Menus { get; set; } = null; 
    }
}
