using LocalExperience.AppServices.Auth.Commands;
using LocalExperience.AppServices.Auth.DTOs;
using LocalExperience.AppServices.Interfaces.Auth;
using LocalExperience.AppServices.Users.DTOs;
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

        public async Task Register(RegisterUserCommand command)
        {
            var isUserExists = await _userRepository.GetByEmail(command.Email);
            if (isUserExists != null) throw new ArgumentException("Usuário já existe.");

            if (command.Password != command.ConfirmPassword) throw new ArgumentException("As senhas não coincidem.");

            var hashedPassword = PasswordHasher.HashPassword(command.Password);
            var user = new User(command.Email, command.Name);
            user.SetPasswordHash(hashedPassword);

            await _userRepository.Create(user);
        }

        public async Task<AuthDto> Login(LoginUserCommand command)
        {
            var user = await _userRepository.GetByEmail(command.Email);
            if (user == null) throw new KeyNotFoundException("Email ou senha inválidos.");

            var isPasswordValid = PasswordHasher.VerifyPassword(command.Password, user.PasswordHash);
            if (isPasswordValid == false) throw new UnauthorizedAccessException("Email ou senha inválidos.");

            return new AuthDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                CreateDate = user.CreateDate
            };
        }
    }
}
