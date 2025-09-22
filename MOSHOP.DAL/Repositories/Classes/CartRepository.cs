using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MOSHOP.DAL.Data;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.DAL.Repositories.Classes
{

    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            return _context.SaveChanges();
        }

        public async Task<bool> ClearCartAsync(string userId)
        {
            var items = _context.Carts.Where(c => c.UserId == userId).ToList();
            _context.Carts.RemoveRange(items);

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Cart>> GetUserCartAsync(string userId)
        {
            return await _context.Carts.Include(c => c.Product).Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
