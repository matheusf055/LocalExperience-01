using LocalExperience.AppServices.Interfaces.Auth;
using LocalExperience.AppServices.Interfaces.Users.DTOs;
using LocalExperience.Domain.Users;
using LocalExperience.Domain.Users.Repositories;
using LocalExperience.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Auth
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUserRepository _userRepository;

        public AuthAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Register(UserRegisterDto userDto)
        {
            var isUserExists = await _userRepository.GetByEmail(userDto.Email);
            if (isUserExists != null) throw new ArgumentException("Usuário já existe.");

            var hashedPassword = PasswordHasher.HashPassword(userDto.Password);
            var user = new User(userDto.Email, userDto.Name);
            user.SetPasswordHash(hashedPassword);

            await _userRepository.Create(user);
        }

        public async Task<UserDto> Login(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByEmail(loginDto.Email);
            if (user == null) throw new KeyNotFoundException("Email ou senha inválidos.");

            var isPasswordValid = PasswordHasher.VerifyPassword(user.PasswordHash, loginDto.Password);
            if (isPasswordValid == false) throw new UnauthorizedAccessException("Email ou senha inválidos.");

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                CreateDate = user.CreateDate
            };
        }
    }
}
