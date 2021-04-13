﻿using PoznajPrz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajPrz.Domain.Interfaces.Repositories
{
    public interface IFriendRepository
    {
        Task CreateAsync(Friend invitation);
        Task UpdateAsync(Friend friend);
        Task RemoveAsync(Friend friend);
    }
}