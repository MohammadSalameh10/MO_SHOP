using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface ICartService
    {
       Task<bool> AddToCartAsync(CartRequest request, string userId);

       Task<CartSummaryResponse> CartSummaryResponseAsync(string userId);

        Task<bool> ClearCartAsync(string userId);
    }
}
