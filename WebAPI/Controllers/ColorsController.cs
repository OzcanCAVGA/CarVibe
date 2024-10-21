using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult AddColor(Color color)
        {
            if (color != null)
            {
                _colorService.AddColor(color);
                return Ok(Messages.Added);
            }

            return BadRequest(Messages.NotFound);
        }
        [HttpPost("update")]
        public IActionResult UpdateColor(Color color)
        {
            if (color == null)
            {
                return BadRequest(Messages.NotFound);
            }

            var existingColor = _colorService.GetColorById(color.ID);
            if (existingColor.Success == false)
            {
                return NotFound(Messages.NotFound);
            }

            _colorService.UpdateColor(color);
            return Ok(Messages.Updated);
        }


        [HttpPost("delete")]
        public IActionResult DeleteColor(Color color)
        {
            if (color != null)
            {
                _colorService.DeleteColor(color);
                return Ok(Messages.Deleted);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetColors();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(Messages.NotFound);
        }

        [HttpGet("getcolorbyid")]
        public IActionResult GetColor(int id)
        {
            var result = _colorService.GetColorById(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(Messages.NotFound);
        }
    }
}
