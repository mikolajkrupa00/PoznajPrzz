﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Users.AutheticateUser
{
    public class AutheticateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
