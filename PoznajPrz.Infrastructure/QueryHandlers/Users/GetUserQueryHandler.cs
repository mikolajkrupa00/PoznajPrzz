using MediatR;
using Microsoft.EntityFrameworkCore;
using PoznajPrz.Application.Queries.Users.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.QueryHandlers.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        public readonly PoznajPrzContext _context;

        public GetUserQueryHandler(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user =  await (from u in _context.Users
                          where u.UserId == request.UserId
                          select new UserDto(u.UserId, u.Email, u.Username, u.Role)).FirstAsync();
            return user;
        }
    }
}
