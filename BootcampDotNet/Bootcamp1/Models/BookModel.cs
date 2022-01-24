using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bootcamp1.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public int Quantity { get; set; }
    }
   
}
