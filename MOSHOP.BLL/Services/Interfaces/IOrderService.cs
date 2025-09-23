using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.Models;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> GetUserByOrderAsync(int orderId);
        Task<Order?> AddOrderAsync(Order order);
        Task<List<Order>> GetByStatusAsync(OrderStatus status);
        Task<List<Order>> GetOrderByUserAsync(string userId);
        Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus);
    }
}
