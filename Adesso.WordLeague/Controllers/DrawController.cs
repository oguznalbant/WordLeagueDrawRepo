using Adesso.WordLeague.DTO;
using Adesso.WordLeague.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.WordLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IDrawService _drawService;

        public DrawController(IDrawService drawService)
        {
            _drawService = drawService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DrawDto))]
        public async Task<IActionResult> CreateDraw([FromBody] CreateDrawDto createDrawDto)
        {
            if (createDrawDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _drawService.CreateDrawAsync(createDrawDto));
        }
    }
}
