

using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        int Add(Cart cart);

        List<Cart> GetUserCart(string userId);
    }
}
