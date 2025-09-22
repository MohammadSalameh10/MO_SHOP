

using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<int> AddAsync(Cart cart);

        Task<List<Cart>> GetUserCartAsync(string userId);
        Task<bool> ClearCartAsync(string userId);
    }
}
