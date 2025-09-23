using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> BlockUserAsync(string userId, int days)
        {
           return await _userRepository.BlockUserAsync(userId, days);
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Adapt<List<UserDTO>>();
        }

        public async Task<UserDTO> GetByIdAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user.Adapt<UserDTO>();
        }

        public async Task<bool> IsBlockUserAsync(string userId)
        {
          return await  _userRepository.IsBlockUserAsync(userId);
        }

        public async Task<bool> UnBlockUserAsync(string userId)
        {
           return await _userRepository.UnBlockUserAsync(userId);
        }
    }
}
