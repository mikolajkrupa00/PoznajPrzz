using Microsoft.EntityFrameworkCore;
using PoznajPrz.Domain.Interfaces.Repositories;
using PoznajPrz.Domain.Models;
using PoznajPrz.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Infrastructure.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly PoznajPrzContext _context;

        public FriendRepository(PoznajPrzContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Friend invitation)
        {
            await _context.Friends.AddAsync(DbFriend.Create(invitation.User1Id, invitation.User2Id));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Friend friend)
        {
            var _friend = await (from f in _context.Friends
                                 where f.User1Id == friend.User1Id
                                 select f).FirstAsync();
            _friend.IsAccepted = friend.IsAccepted;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Friend friend)
        {
            var _friend = await (from f in _context.Friends
                                 where f.User1Id == friend.User1Id && f.User2Id == friend.User2Id
                                 select f).FirstAsync();
            _context.Friends.Remove(_friend);
            await _context.SaveChangesAsync();
        }
    }
}
