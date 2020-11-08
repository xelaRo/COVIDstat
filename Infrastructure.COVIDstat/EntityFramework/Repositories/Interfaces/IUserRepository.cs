using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.COVIDstat.EntityFramework.Entities;

namespace Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid userId);
        Task<User> GetUser(string email,string password);
    }
}
