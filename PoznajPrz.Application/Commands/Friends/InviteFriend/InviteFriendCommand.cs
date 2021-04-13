﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Application.Commands.Friends.InviteFriend
{
    public class InviteFriendCommand : IRequest<Unit>
    {
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
    }
}
