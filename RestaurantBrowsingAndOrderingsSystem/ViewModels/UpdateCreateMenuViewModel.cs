using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RestaurantBrowsingAndOrderingsSystem.ViewModels
{
    public class UpdateCreateMenuViewModel
    {
        public int MeneId { get; set; }
        public int RestaurantId { get; set; }
        [ValidateNever]
        public string RestaurantName { get; set; } = null!;
        
        [Required(ErrorMessage = "Select Menu Type")]

        public string Type { get; set; } = null!;
        [Required (ErrorMessage = "Enter Menu Description")]
        public string Description { get; set; } = null!;
    }
}
