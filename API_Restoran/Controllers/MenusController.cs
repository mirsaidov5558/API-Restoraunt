using API_Restoran.DTOs.MenuDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _srv;

        public MenusController(IMenuService srv) => _srv = srv;

        [HttpGet]
        public async Task<IEnumerable<MenuDto>> GetAll()
            => await _srv.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MenuDto>> GetById(int id)
        {
            var item = await _srv.GetByIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<MenuDto>> Post(CreateMenuDto dto)
        {
            var created = await _srv.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => await _srv.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
