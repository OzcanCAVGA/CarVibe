using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllUsers();
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUserById(id);
            if (result == null)
            {
                return BadRequest(Messages.NotFound);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest(Messages.NameInvalid);
            }
            _userService.AddUser(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) 
        {
            var result = _userService.GetUserById(user.ID);
            if(result.Success)
            {
                _userService.UpdateUser(user);
                return Ok(user);
            }
            return BadRequest(Messages.NameInvalid);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.GetUserById(id);
            if(result.Success)
            {
                _userService.DeleteUser(result.Data);
                return Ok(Messages.Deleted); 
            }
            return BadRequest(Messages.NotFound);
        }
    }
}
