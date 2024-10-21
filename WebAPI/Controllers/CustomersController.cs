using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(Messages.NameInvalid);
            }
            _customerService.AddCustomer(customer);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var result = _customerService.GetCustomerById(customer.ID);
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            _customerService.UpdateCustomer(customer);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var result = _customerService.GetCustomerById(id);
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            _customerService.DeleteCustomer(result.Data);
            return Ok(Messages.Deleted);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            var result = _customerService.GetCustomerById(id);
            if (result == null)
            { return BadRequest(Messages.NotFound); }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            return Ok(result);
        }

    }
}


