using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class UpdateCreateMealViewModel
    {
        public int MealId { get; set; } 
        public int MenuId { get;  set; }

        public int RestaurantId { get; set; }   
        [ValidateNever]
        public string MenuName { get; set; } = null!;  
        
        [MaxLength(50)]
        [Required (ErrorMessage = " Please Enter Meal Name ")]
        [Display(Name = "Meal Name  ")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = " Please Enter Meal Description ")]
        [MaxLength(50)]
        [Display(Name = "Meal Description ")]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;
        [Required(ErrorMessage = " Please Enter Meal Price ")]
        [Display(Name = "Meal Price ")]
        public double Price { get; set; }
        [Display (Name = "Set Offer !")]
        public double? Offer { get; set; }
        // for meal image 
        [Display(Name = "Upload Image  !")]
        public IFormFile ? Image { get; set; }  
    }
}
