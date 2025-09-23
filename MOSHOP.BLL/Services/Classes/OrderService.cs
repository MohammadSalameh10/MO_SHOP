using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) {
        
            _orderRepository = orderRepository;
        }
        public async Task<Order?> AddOrderAsync(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public Task<bool> ChangeStatusAsync(int orderId, OrderStatus newStatus)
        {
            return _orderRepository.ChangeStatusAsync(orderId, newStatus);
        }

        public Task<List<Order>> GetByStatusAsync(OrderStatus status)
        {
           return _orderRepository.GetByStatusAsync(status);
        }

        public Task<List<Order>> GetOrderByUserAsync(string userId)
        {
            return _orderRepository.GetOrderByUserAsync(userId);
        }

        public Task<Order?> GetUserByOrderAsync(int orderId)
        {
            return _orderRepository.GetUserByOrderAsync(orderId);
        }
    }
}
