using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;
using Infrastructure.COVIDstat.JwtProvider;

namespace Domain.COVIDstat.Interfaces
{
    public interface IUserService
    {
        Task<Token> AuthenticateUser(UserDTO userDto);
    }
}
