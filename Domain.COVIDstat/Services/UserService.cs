using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.COVIDstat.DTOs;
using Domain.COVIDstat.Interfaces;
using Infrastructure.COVIDstat.EntityFramework.Repositories.Interfaces;
using Infrastructure.COVIDstat.JwtProvider;

namespace Domain.COVIDstat.Services
{
    public class UserService : IUserService
    {
        private IJwtFactory _JwtFactory;
        private IUserRepository _userRepository;

        public UserService(IJwtFactory jwtFactory, IUserRepository userRepository)
        {
            _JwtFactory = jwtFactory;
            _userRepository = userRepository;
        }

        public async Task<Token> AuthenticateUser(UserDTO userDto)
        {
            var user = await _userRepository.GetUser(userDto.Email, userDto.Password);

            if (user == null)
            {
                throw new ArgumentException($"The user with email {userDto.Email} cannot be found.");
            }

            var token = await _JwtFactory.GenerateEncodedToken(user.UserId.ToString(), user.Email);

            return token;
        }
    }
}
