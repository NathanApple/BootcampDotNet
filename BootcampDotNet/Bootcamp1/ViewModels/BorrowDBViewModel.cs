using Bootcamp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.ViewModels
{
    public class BorrowDBViewModel
    {
        public List<BorrowModel> BorrowList { get; set; }
        public BorrowModel Borrow { get; set; }
        public List<UserModel> UserList { get; set; }
        public UserModel User { get; set; }
        public List<BookModel> BookList { get; set; }
        public BookModel Book { get; set; }
    }
}
