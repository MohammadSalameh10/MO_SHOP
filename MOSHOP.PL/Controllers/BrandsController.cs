using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOSHOP.BLL.Services.Interfaces;
using MOSHOP.DAL.DTO.Requests;

namespace MOSHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BrandsController : ControllerBase
    {
        public readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
       
    }
}
