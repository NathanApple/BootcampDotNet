using Bootcamp1.Models;
using Bootcamp1.Services;
using Bootcamp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            List<UserModel> users = userService.GetUsers();
            BookModel book = new BookModel()
            {
                BookID = 1,
                BookTitle = "asd"
            };
            UserViewModel uvm = new UserViewModel()
            {
                Users = users,
                Book = book
            };

            return View(uvm);
        }

        public IActionResult Welcome()
        {
            //Views/{User}/{Welcome}.cshtml
            UserViewModel uvm = new UserViewModel();
            uvm.Message = "halo dari model";
            uvm.User = new UserModel()
            {
                UserName = "leo",
            };
            uvm.Book = new BookModel()
            {
                BookTitle = "1984"
            };
            return View(uvm);
        }


    

        public UserModel GetUser(int id)
        {
            UserModel user = userService.GetUser(id);
            return user;
        }

       
    }
}
