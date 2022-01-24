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
    public class BookDBController : Controller
    {
        //dependency injection (taruh aja semua service yg dibutuhkan di sini)
        private readonly UserService userService;
        private readonly BookService bookService;

        public BookDBController(UserService userService, BookService bookService)
        {
            this.userService = userService;
            this.bookService = bookService;

        }

        public async Task<IActionResult> Index()
        {
            BookDBViewModel BookDBVM = new BookDBViewModel();

            List<UserModel> users = await userService.GetAllUser();

            BookDBVM.UserList = users; 


            return View("Menu", BookDBVM);
        }

        public async Task<IActionResult> CreateFromAjax( BookDBViewModel ModelSubmit)
        {

            // Jadi... pas  kita mau create, kan ID nya null tuh
            // jdinya kita mesti remove Book.BookID dari validasi, kalau gk ntar dia bakal dicegat, gk lolos validasi. Coba aja komen 1 baris code di bawah ini, nnti eror.
            ModelState.Remove("Book.BookID");


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






            BookModel result = await bookService.CreateBook(ModelSubmit.Book);

            //annonymous object
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Create From Ajax"
            });

            return Ret;
        }

        public async Task<IActionResult> GetAllBook()
        {
            BookDBViewModel BookDBVM = new BookDBViewModel();
            var books = await bookService.GetAllBook();
            BookDBVM.BookList = books;
            return View("_BookList", BookDBVM);
        }

     

        public async Task<IActionResult> DeleteBookAsync(int bookId)
        {
            await bookService.DeleteBook(bookId);
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Delete"
            });
            return Ret;

        }



        public async Task<IActionResult> UpdateBookAsync(BookDBViewModel ModelSubmit)
        {
            await bookService.UpdateBook(ModelSubmit.Book);

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Update"
            });
            return Ret;

        }

        public async Task<IActionResult> BorrowBookAsync(BorrowDBViewModel ModelSubmit)
        {
            await bookService.BorrowBook(ModelSubmit.Borrow);

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Update"
            });
            return Ret;

        }


    }
}
