using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class FoodService
    {

        private BootcampDotNetDBContext dbContext;

        public FoodService(BootcampDotNetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<FoodModel>> GetAllFood()
        {

            //get all
            //List<FoodEntity> foods = await dbContext.Food.ToListAsync();

            //pakai where first
            //default = new FoodEntity();

            FoodEntity food = await dbContext.Food.Where(e => e.FoodID == 2).FirstOrDefaultAsync();

            //step1: dbContext.Entity
            //step2: .Where .Include --urutannya bebas, bisa pakai sebanyak apapun
            //step2.5: map entity  ke model

            //step3: .ToListAsync() ATAU .FirstOrDefaultAsync() --hanya bisa salah satu


            //Entity => circular

            //problem: entity circular
            //FoodEntity z = await dbContext.Food
            //    .Where(e => e.Price == 12.3)
            //    .Where(e => e.ChefID == 2)
            //    .Where(e => e.Chef.ChefName == "budi")
            //    .Include(e => e.Chef)
            //    .FirstOrDefaultAsync();

            List<FoodModel> y = await dbContext.Food
                .Include(e => e.Chef)
                .Select(e => new FoodModel()
                {
                    FoodID = e.FoodID,
                    FoodName = e.FoodName,
                    Price = e.Price,
                    ChefName = e.Chef.ChefName,
                    ChefID = e.Chef.ChefID
                })
                .ToListAsync();

            //where, list
            //List<FoodEntity> foods2 = await dbContext.Food.Where(e => e.ChefID == 1).ToListAsync();

            //List<ChefEntity> chefs = await dbContext.Chef.ToListAsync();
            //var foods = await dbContext.Food.Include(e => e.Chef)
            //    .Select(e => new FoodModel()
            //    {
            //        FoodName = e.FoodName,
            //        FoodID = e.FoodID,
            //        Price = e.Price,
            //        ChefName = e.Chef.ChefName
            //    }).ToListAsync();



            return y;

        }

        public async Task<FoodModel> CreateFood(FoodModel food)
        {
            FoodEntity z = new FoodEntity()
            {
                FoodName = food.FoodName,
                Price = food.Price,
                ChefID = food.ChefID
            };

            var res = await dbContext.AddAsync(z);
            await dbContext.SaveChangesAsync();

            return new FoodModel()
            {
                FoodID = res.Entity.FoodID,
                FoodName = res.Entity.FoodName,
                Price = res.Entity.Price
            };

        }


        public async Task DeleteFood(int foodId)
        {
            FoodEntity food = await dbContext.Food
                        .Where(e => e.FoodID == foodId)
                        .FirstOrDefaultAsync();

            dbContext.Remove(food);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateFood(FoodModel modelUpdate)
        {
            FoodEntity food = await dbContext.Food
                        .Where(e => e.FoodID == modelUpdate.FoodID)
                        .FirstOrDefaultAsync();

            food.FoodName = modelUpdate.FoodName;
            food.Price = modelUpdate.Price;
            food.ChefID = modelUpdate.ChefID;

            await dbContext.SaveChangesAsync();

        }

    }
}
