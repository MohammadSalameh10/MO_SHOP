using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task AddRangeAsync(List<OrderItem> orderItem);
    }
}
