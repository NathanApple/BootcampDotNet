using Bootcamp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.ViewModels
{
    public class FoodDBViewModel
    {
        public List<FoodModel> FoodList { get; set; }
        public FoodModel Food { get; set; }
        public List<ChefModel> ChefList { get; set; }
        public  ChefModel Chef { get; set; }
    }
}
