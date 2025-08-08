using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Requests;
using MOSHOP.DAL.DTO.Responses;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.BLL.Services.Classes
{
    public class BrandService : GenericService<BrandRequest, BrandResponses, Brand>, IBrandService
    {
        public BrandService(IBrandRepository brandRepository) : base(brandRepository)
        {
        }
       
    }
}
