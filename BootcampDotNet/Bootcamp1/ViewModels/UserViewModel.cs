using Bootcamp1.Models;
using System.Collections.Generic;

namespace Bootcamp1.ViewModels
{
    public class UserViewModel
    {
        public List<UserModel> Users { get; set; }
        public BookModel Book { get; set; }
        public UserModel User { get; set; }
        public string Message { get; set; }
    }
}
