using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bootcamp1.Models
{
    public class BorrowModel
    {
        public int BorrowID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }

        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public int Quantity { get; set; }
    }
   
}
