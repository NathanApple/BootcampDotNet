using Bootcamp1.CustomValidations.FoodValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Bootcamp1.Models
{
    public class FoodModel
    {
        
        public int FoodID { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Minimal 3 huruf ya guys")]
        [Display(Name = "Food Name")]
        public string FoodName { get; set; }
        [CustomPriceValidation]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Must be 2 digits behind dot")]
        public double Price { get; set; } = 0;
        public string ChefName { get; set; }
        public int ChefID { get; set; }

    }
}
