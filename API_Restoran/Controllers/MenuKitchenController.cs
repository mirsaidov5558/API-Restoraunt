using API_Restoran.DTOs.MenuKitchenDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuKitchenController : ControllerBase
    {
        private readonly IMenuKitchenService _srv;

        public MenuKitchenController(IMenuKitchenService srv) => _srv = srv;

        [HttpGet]
        public async Task<IEnumerable<MenuKitchenDto>> GetAll() => await _srv.GetAllAsync();

        [HttpGet("order/{orderId:int}")]
        public async Task<ActionResult<MenuKitchenDto>> GetByOrder(int orderId)
        {
            var dto = await _srv.GetByOrderAsync(orderId);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MenuKitchenDto>> Post(CreateMenuKitchenDto dto)
        {
            var created = await _srv.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByOrder), new { orderId = created.OrderId }, created);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => await _srv.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
