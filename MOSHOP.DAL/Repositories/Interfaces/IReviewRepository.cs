using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<bool> UserHasReviewedProductAsync(string userId, int productId);
        Task AddReviewAsync(Review request, string userId);
    }
}
