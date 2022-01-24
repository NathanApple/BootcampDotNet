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
    public class BorrowDBController : Controller
    {
        //dependency injection (taruh aja semua service yg dibutuhkan di sini)
        private readonly UserService userService;

        private readonly BorrowService borrowService;
        public BorrowDBController(BorrowService borrowService, UserService userService)
        {
            this.userService = userService;

            this.borrowService = borrowService;
        }

        public async Task<IActionResult> Index()
        {
            BorrowDBViewModel BorrowDBVM = new BorrowDBViewModel();

            List<UserModel> users = await userService.GetAllUser();

            BorrowDBVM.UserList = users;


            return View("Menu", BorrowDBVM);
        }

        public async Task<IActionResult> CreateFromAjax(BorrowDBViewModel ModelSubmit)
        {

            // Jadi... pas  kita mau create, kan ID nya null tuh
            // jdinya kita mesti remove Borrow.BorrowID dari validasi, kalau gk ntar dia bakal dicegat, gk lolos validasi. Coba aja komen 1 baris code di bawah ini, nnti eror.
            ModelState.Remove("Borrow.BorrowID");


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

           

            BorrowModel result = await borrowService.CreateBorrow(ModelSubmit.Borrow);

            //annonymous object
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Create From Ajax"
            });

            return Ret;
        }

        public async Task<IActionResult> GetAllBorrow()
        {
            BorrowDBViewModel BorrowDBVM = new BorrowDBViewModel();
            var borrows = await borrowService.GetAllBorrow();
            BorrowDBVM.BorrowList = borrows;
            return View("_BorrowList", BorrowDBVM);
        }

        public async Task<IActionResult> GetBorrowFromUser(int userId)
        {
            BorrowDBViewModel BorrowDBVM = new BorrowDBViewModel();
            var borrows = await borrowService.GetBorrowFromUser(userId);
            BorrowDBVM.BorrowList = borrows;
            return View("_BorrowList", BorrowDBVM);
        }


        // Low Pri
        //public async Task<IActionResult> DeleteBorrowAsync(int borrowId)
        //{
        //    await borrowService.DeleteBorrow(borrowId);
        //    JsonResult Ret = Json(new
        //    {
        //        Status = true,
        //        Message = "Berhasil Delete"
        //    });
        //    return Ret;

        //}



        //public async Task<IActionResult> UpdateBorrowAsync(BorrowDBViewModel ModelSubmit)
        //{
        //    await borrowService.UpdateBorrow(ModelSubmit.Borrow);

        //    JsonResult Ret = Json(new
        //    {
        //        Status = true,
        //        Message = "Berhasil Update"
        //    });
        //    return Ret;

        //}


    }
}
