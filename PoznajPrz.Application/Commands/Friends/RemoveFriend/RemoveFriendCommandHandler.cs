﻿using MediatR;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Friends.RemoveFriend
{
    public class RemoveFriendCommandHandler : IRequestHandler<RemoveFriendCommand, Unit>
    {
        private readonly IFriendRepository _friendRepository;

        public RemoveFriendCommandHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<Unit> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            await _friendRepository.RemoveAsync(new Friend(request.User1Id, request.User2Id, false));
            return Unit.Value;
        }
    }
}
