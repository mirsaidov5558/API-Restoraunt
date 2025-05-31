using API_Restoran.DTOs.IngredientDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _srv;
        public IngredientsController(IIngredientService srv)
        {
            _srv = srv;
        }

        [HttpGet]
        public async Task<IEnumerable<IngredientDto>> Get() => await _srv.GetAllAsync();


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        => (await _srv.GetByIdAsync(id)) switch
        {
            null => NotFound(),
            var dto => Ok(dto)
        };


        [HttpPost]
        public async Task<IActionResult> Post(CreateIngredientDto dto)
        {
            var created = await _srv.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UpdateIngredientDto dto)
            => (await _srv.UpdateAsync(id, dto)) switch
            {
                null => NotFound(),
                var updated => Ok(updated)
            };

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => await _srv.DeleteAsync(id) ? NoContent() : NotFound();

    }
}
