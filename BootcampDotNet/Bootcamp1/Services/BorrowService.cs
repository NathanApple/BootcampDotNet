using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class BorrowService
    {

        private BootcampDotNetDBContext dbContext;

        public BorrowService(BootcampDotNetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // changed later
        public async Task<List<BorrowModel>> GetBorrowFromUser(int userId)
        {
            //BorrowEntity borrow = await dbContext.Borrow.Where(e => e.UserID == userId).FirstOrDefaultAsync();

            List<BorrowModel> y = await dbContext.Borrow
            .Select(e => new BorrowModel()
            {
                BorrowID = e.BorrowID,
                BookID = e.BookID,
                UserID = e.UserID,
                BookTitle = e.Book.BookTitle,
                BookDescription = e.Book.BookDescription
            }).Where(e => e.UserID == userId)
            .ToListAsync();

            return y;

        }

        public async Task<List<BorrowModel>> GetAllBorrow()
        {

            //get all
            //List<BorrowEntity> borrows = await dbContext.Borrow.ToListAsync();

            //pakai where first
            //default = new BorrowEntity();



            //step1: dbContext.Entity
            //step2: .Where .Include --urutannya bebas, bisa pakai sebanyak apapun
            //step2.5: map entity  ke model

            //step3: .ToListAsync() ATAU .FirstOrDefaultAsync() --hanya bisa salah satu


            //Entity => circular

            //problem: entity circular
            //BorrowEntity z = await dbContext.Borrow
            //    .Where(e => e.Price == 12.3)
            //    .Where(e => e.ChefID == 2)
            //    .Where(e => e.Chef.ChefName == "budi")
            //    .Include(e => e.Chef)
            //    .FirstOrDefaultAsync();

            List<BorrowModel> y = await dbContext.Borrow
                .Select(e => new BorrowModel()
                {
                    BorrowID = e.BorrowID,
                    BookID = e.BookID,
                    UserID = e.UserID,
                })
                .ToListAsync();

            //where, list
            //List<BorrowEntity> borrows2 = await dbContext.Borrow.Where(e => e.ChefID == 1).ToListAsync();

            //List<ChefEntity> chefs = await dbContext.Chef.ToListAsync();
            //var borrows = await dbContext.Borrow.Include(e => e.Chef)
            //    .Select(e => new BorrowModel()
            //    {
            //        BorrowTitle = e.BorrowTitle,
            //        BorrowID = e.BorrowID,
            //        Price = e.Price,
            //        ChefName = e.Chef.ChefName
            //    }).ToListAsync();



            return y;

        }

        public async Task<BorrowModel> CreateBorrow(BorrowModel borrow)
        {
            BorrowEntity z = new BorrowEntity()
            {
                BookID = borrow.BookID,
                UserID = borrow.UserID,
                
            };

            var res = await dbContext.AddAsync(z);
            await dbContext.SaveChangesAsync();

            return new BorrowModel()
            {
                BorrowID = res.Entity.BorrowID,
                BookID = res.Entity.BookID,
                UserID = res.Entity.UserID,
            };

        }



        // Low Priority
        //public async Task DeleteBorrow(int borrowId)
        //{
        //    BorrowEntity borrow = await dbContext.Borrow
        //                .Where(e => e.BorrowID == borrowId)
        //                .FirstOrDefaultAsync();

        //    dbContext.Remove(borrow);
        //    await dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateBorrow(BorrowModel modelUpdate)
        //{
        //    BorrowEntity borrow = await dbContext.Borrow
        //                .Where(e => e.BorrowID == modelUpdate.BorrowID)
        //                .FirstOrDefaultAsync();

        //    borrow.BorrowTitle = modelUpdate.BorrowTitle;
        //    borrow.UserID = modelUpdate.UserID;
        //    borrow.Quantity = modelUpdate.Quantity;

        //    await dbContext.SaveChangesAsync();

        //}

    }
}
