using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            if (car != null)
            {
                _carService.Add(car);
                return Ok(Messages.Added);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            if (car != null)
            {
                _carService.Update(car);
                return Ok(Messages.Updated);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carService.GetCarById(id);
            if (result != null)
            {
                _carService.Delete(result);
                return Ok(Messages.Deleted);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetCarById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandid)
        {
            var result = _carService.GetCarsByBrandId(brandid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColor(int colorid)
        {
            var result = _carService.GetCarsByColorId(colorid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



    }
}
