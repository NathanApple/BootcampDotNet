using Bootcamp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.ViewModels
{
    public class FoodViewModel
    {
        public List<FoodModel> FoodList { get; set; }
        public FoodModel Food { get; set; }
    }
}
