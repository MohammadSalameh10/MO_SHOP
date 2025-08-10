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
using MOSHOP.DAL.Repositories.Classes;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class BrandService : GenericService<BrandRequest, BrandResponses, Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFIleService _fileService;
        public BrandService(IBrandRepository brandRepository, IFIleService fileService) : base(brandRepository)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateFileAsync(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;

            if (request.MainImage != null)
            {
                var imagePath = await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }
            return _brandRepository.Add(entity);
        }
    }
}
