using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class BookService
    {

        private BootcampDotNetDBContext dbContext;

        public BookService(BootcampDotNetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BookModel>> GetAllBook()
        {

            //get all
            //List<BookEntity> books = await dbContext.Book.ToListAsync();

            //pakai where first
            //default = new BookEntity();

            BookEntity book = await dbContext.Book.Where(e => e.BookID == 2).FirstOrDefaultAsync();
        
            //step1: dbContext.Entity
            //step2: .Where .Include --urutannya bebas, bisa pakai sebanyak apapun
            //step2.5: map entity  ke model
            
            //step3: .ToListAsync() ATAU .FirstOrDefaultAsync() --hanya bisa salah satu


            //Entity => circular

            //problem: entity circular
            //BookEntity z = await dbContext.Book
            //    .Where(e => e.Price == 12.3)
            //    .Where(e => e.ChefID == 2)
            //    .Where(e => e.Chef.ChefName == "budi")
            //    .Include(e => e.Chef)
            //    .FirstOrDefaultAsync();

            List<BookModel> y = await dbContext.Book
                .Select(e => new BookModel()
                {
                    BookID = e.BookID,
                    BookTitle = e.BookTitle,
                    BookDescription = e.BookDescription,
                    Quantity = e.Quantity,
                })
                .ToListAsync();

            //where, list
            //List<BookEntity> books2 = await dbContext.Book.Where(e => e.ChefID == 1).ToListAsync();

            //List<ChefEntity> chefs = await dbContext.Chef.ToListAsync();
            //var books = await dbContext.Book.Include(e => e.Chef)
            //    .Select(e => new BookModel()
            //    {
            //        BookTitle = e.BookTitle,
            //        BookID = e.BookID,
            //        Price = e.Price,
            //        ChefName = e.Chef.ChefName
            //    }).ToListAsync();



            return y;

        }

        public async Task<BookModel> CreateBook(BookModel book)
        {
            BookEntity z = new BookEntity()
            {
                BookTitle = book.BookTitle,
                BookDescription = book.BookDescription,
                Quantity = book.Quantity,
            };

            var res = await dbContext.AddAsync(z);
            await dbContext.SaveChangesAsync();

            return new BookModel()
            {
                BookID = res.Entity.BookID,
                BookTitle = res.Entity.BookTitle,
                BookDescription = res.Entity.BookDescription,
                Quantity = res.Entity.Quantity
            };

        }

        public async Task<BorrowModel> BorrowBook(BorrowModel borrow)
        {
            BorrowEntity z = new BorrowEntity()
            {
                BookID = borrow.BookID,
                UserID = borrow.UserID,
            };
            var res = await dbContext.AddAsync(z);
            await dbContext.SaveChangesAsync();

            BookEntity book = await dbContext.Book
            .Where(e => e.BookID == borrow.BookID)
            .FirstOrDefaultAsync();

            book.Quantity = book.Quantity - 1;

            await dbContext.SaveChangesAsync();
            //string aSQL = "UPDATE products set quantity=quantity-1" + Request.QueryString["quant"] + "Where Id=" + Request.QueryString["Id"];

            return new BorrowModel()
            {
                BorrowID = res.Entity.BorrowID,
                BookID = res.Entity.BookID,
                UserID = res.Entity.UserID,

            };
        }

        public async Task DeleteBook(int bookId)
        {
            BookEntity book = await dbContext.Book
                        .Where(e => e.BookID == bookId)
                        .FirstOrDefaultAsync();

            dbContext.Remove(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(BookModel modelUpdate)
        {
            BookEntity book = await dbContext.Book
                        .Where(e => e.BookID == modelUpdate.BookID)
                        .FirstOrDefaultAsync();

            book.BookTitle = modelUpdate.BookTitle;
            book.BookDescription = modelUpdate.BookDescription;
            book.Quantity = modelUpdate.Quantity;

            await dbContext.SaveChangesAsync();

        }

    }
}
