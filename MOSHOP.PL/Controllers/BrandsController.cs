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

        [HttpGet("")]

        public IActionResult GetAll()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var category = _brandService.GetById(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _brandService.Create(request);
            if (id == 0)
            {
                return BadRequest("Brand  could not be created.");
            }
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPatch("{id}")]

        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var updated = _brandService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{id}")]

        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var result = _brandService.ToggleStatus(id);
            return result ? Ok(new { message = "status toggled" }) : NotFound(new { message = "brand not found" });
        }

        [HttpDelete("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = _brandService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();

        }
    }
}
