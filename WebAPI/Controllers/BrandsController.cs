using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest(Messages.NameInvalid);
            }
            _brandService.Add(brand);
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.GetById(brand.ID);
            if (result.Success)
            {
                _brandService.Update(brand);

                return Ok(result);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = (_brandService.GetById(id));
            if (result.Success)
            {
                _brandService.Delete(result.Data);
                return Ok(result.Message);
            }
            return BadRequest(Messages.NotFound);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _brandService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}