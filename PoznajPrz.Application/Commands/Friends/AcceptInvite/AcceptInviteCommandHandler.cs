using MediatR;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Friends.AcceptInvite
{
    public class AcceptInviteCommandHandler : IRequestHandler<AcceptInviteCommand, Unit>
    {
        private readonly IFriendRepository _friendRepository;

        public AcceptInviteCommandHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<Unit> Handle(AcceptInviteCommand request, CancellationToken cancellationToken)
        {
            await _friendRepository.UpdateAsync(new Friend(request.User1Id, request.User2Id, true));
            return Unit.Value;
        }
    }
}
