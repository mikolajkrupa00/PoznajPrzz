﻿using MediatR;
using PoznajPrz.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PoznajPrz.Domain.Models;
using PoznajPrz.Domain.Interfaces.Services;

namespace PoznajPrz.Application.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IJwtGenerator jwtGenerator, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var salt = _passwordHasher.GenerateSalt();
            var password = _passwordHasher.GenerateHash(request.Password, salt);
            var user = User.Create(request.Email, request.Username, password, salt, Domain.Enums.Roles.User);
            await _userRepository.CreateAsync(user);
            var token = _jwtGenerator.Generate(user.UserId, Domain.Enums.Roles.User);
            return new UserDto(user.UserId, token);
        }
    }
}
