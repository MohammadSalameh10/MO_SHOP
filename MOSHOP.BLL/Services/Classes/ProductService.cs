using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class ProductService : GenericService<ProductRequest, ProductResponse, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFIleService _fileService;
        public ProductService(IProductRepository productRepository, IFIleService fileService) : base(productRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateFileAsync(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;

            if (request.MainImage != null)
            {
                var imagePath = await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }
            return _productRepository.Add(entity);
        }
    }

}
