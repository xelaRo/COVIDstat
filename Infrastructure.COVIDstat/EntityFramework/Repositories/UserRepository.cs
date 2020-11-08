using Infrastructure.COVIDstat.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CovidStatDBContext _ctx;
        public UserRepository(CovidStatDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> GetUser(Guid userId)
        {

            var user = await _ctx.User.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUser(string email, string password)
        {

            var user = await _ctx.User.Where(c => c.Email == email && c.Password.Contains(password)).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<User>> GetUserList()
        {
            List<User> Users = await _ctx.User.ToListAsync();
            return Users;
        }

        public async Task AddUser(User user)
        {
            _ctx.User.Add(user);
        }
    }
}
