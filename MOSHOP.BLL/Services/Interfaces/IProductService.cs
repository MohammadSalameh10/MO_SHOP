using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Models;

namespace MOSHOP.BLL.Services.Interfaces
{
    public interface IProductService : IGenericService<ProductRequest, ProductResponse, Product>
    {
        Task<int> CreateFileAsync(ProductRequest request);
    }
}
