using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAllRental();
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddRental(Rental rental)
        {
            if (rental == null)
            { return BadRequest(Messages.NameInvalid); }
            _rentalService.AddRental(rental);
            return Ok(Messages.Added);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRental(Rental rental)
        {
            var result = _rentalService.GetRentalById(rental.ID);
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            _rentalService.UpdateRental(rental);
            return Ok(Messages.Updated);
        }

        [HttpPut("return/{id}")]
        public IActionResult ReturnCar(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if(result.Success)
            {
                _rentalService.ReturnCar(result.Data);
                return Ok(result);
            }
            return BadRequest(Messages.CarIsNotAvaible);
        }

        [HttpDelete]
        public IActionResult DeleteRental(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success)
            {
                _rentalService.DeleteRental(result.Data);
                return Ok(Messages.Deleted);
            }
            return BadRequest(Messages.NotFound);
        }





    }
}