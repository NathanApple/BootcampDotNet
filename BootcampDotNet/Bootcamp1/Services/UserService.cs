using Bootcamp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class UserService : Controller
    {

        private readonly BootcampDotNetDBContext _dbContext;
        public UserService(BootcampDotNetDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public List<UserModel> GetUsers()
        {

            var users = _dbContext.User.FromSqlInterpolated($"EXECUTE GetUsers").ToList();
            return users;

        }

        public UserModel GetUser(int id)
        {
            var userQuery = _dbContext.User.FromSqlInterpolated($"EXECUTE GetUser {id}");

            var user = userQuery.ToList().FirstOrDefault();
            return user;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            List<UserModel> users = await _dbContext.User
                                    .Select(e => new UserModel()
                                    {
                                        UserID = e.UserID,
                                        UserName = e.UserName
                                    })
                                    .ToListAsync();

            return users;

        }

    }
}
