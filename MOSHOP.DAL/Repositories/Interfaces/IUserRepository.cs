﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string userId);
        Task<bool> BlockUserAsync(string userId, int days);
        Task<bool> UnBlockUserAsync(string userId);
        Task<bool> IsBlockUserAsync(string userId);
        Task<bool> ChangeUserRoleAsync(string userId, string roleName);
    }
}
