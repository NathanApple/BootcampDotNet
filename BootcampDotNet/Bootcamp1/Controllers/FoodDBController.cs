using Bootcamp1.Models;
using Bootcamp1.Services;
using Bootcamp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Controllers
{
    public class FoodDBController : Controller
    {
        //dependency injection (taruh aja semua service yg dibutuhkan di sini)
        private readonly FoodService foodService;
        private readonly ChefService chefService;
        public FoodDBController (FoodService foodService, ChefService chefService)
        {
            this.foodService = foodService;
            this.chefService = chefService;
        }

        public async Task<IActionResult> Index()
        {
            FoodDBViewModel FoodDBVM = new FoodDBViewModel();

            List<ChefModel> chefs = await chefService.GetAllChef();

            FoodDBVM.ChefList = chefs;


            return View("Menu", FoodDBVM);
        }

        public async Task<IActionResult> CreateFromAjax( FoodViewModel ModelSubmit)
        {

            // Jadi... pas  kita mau create, kan ID nya null tuh
            // jdinya kita mesti remove Food.FoodID dari validasi, kalau gk ntar dia bakal dicegat, gk lolos validasi. Coba aja komen 1 baris code di bawah ini, nnti eror.
            ModelState.Remove("Food.FoodID");


            if (ModelState.IsValid == false)
            {
                var errorMessage = ViewData.ModelState.Values
                    .FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;


                JsonResult Ret2 = Json(new
                {
                    Status = false,
                    Message = errorMessage
                });

                return Ret2;

            }






            FoodModel result = await foodService.CreateFood(ModelSubmit.Food);

            //annonymous object
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Create From Ajax"
            });

            return Ret;
        }

        public async Task<IActionResult> GetAllFood()
        {
            FoodDBViewModel FoodDBVM = new FoodDBViewModel();
            var foods = await foodService.GetAllFood();
            FoodDBVM.FoodList = foods;
            return View("_FoodList", FoodDBVM);
        }

     

        public async Task<IActionResult> DeleteFoodAsync(int foodId)
        {
            await foodService.DeleteFood(foodId);
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Delete"
            });
            return Ret;

        }



        public async Task<IActionResult> UpdateFoodAsync(FoodViewModel ModelSubmit)
        {
            await foodService.UpdateFood(ModelSubmit.Food);

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Update"
            });
            return Ret;

        }


    }
}
