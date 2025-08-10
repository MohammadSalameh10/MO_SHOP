using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOSHOP.BLL.Services.Classes;
using MOSHOP.BLL.Services.Interfaces;

namespace MOSHOP.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService brandService)
        {
            _productService = brandService;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
