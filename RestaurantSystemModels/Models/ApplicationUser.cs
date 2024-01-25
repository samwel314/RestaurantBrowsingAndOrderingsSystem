using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RestaurantSystemModels.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FullName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }    
        public DateTime? UpdatedAt { get; set; }

        public DateTime ? Lastseen {  get; set; }   
        [MaxLength(11)]
        public override string? PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    }
}
