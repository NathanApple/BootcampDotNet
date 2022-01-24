using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class ChefService
    {
        private BootcampDotNetDBContext dbContext;

        public ChefService(BootcampDotNetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<ChefModel>> GetAllChef()
        {
            List<ChefModel> chefs = await dbContext.Chef
                                    .Select( e => new ChefModel()
                                    {
                                        ChefID = e.ChefID,
                                        ChefName = e.ChefName
                                    })
                                    .ToListAsync();

            return chefs;


        }


    }
}
