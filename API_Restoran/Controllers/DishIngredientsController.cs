using API_Restoran.DTOs.DishIngredientDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishIngredientsController : ControllerBase
    {
        private readonly IDishIngredientService _srv;

        public DishIngredientsController(IDishIngredientService srv) => _srv = srv;

        // Все связи «блюдо‑ингредиент».
        [HttpGet]
        public async Task<IEnumerable<DishIngredientDto>> GetAll()
            => await _srv.GetAllAsync();

        // Ингредиенты конкретного блюда.
        [HttpGet("dish/{dishId:int}")]
        public async Task<IEnumerable<DishIngredientDto>> GetByDish(int dishId)
            => await _srv.GetByDishAsync(dishId);

        // Добавить ингредиент в блюдо.
        [HttpPost]
        public async Task<IActionResult> Post(CreateDishIngredientDto dto)
        {
            var created = await _srv.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = created!.Id }, created);
        }

        // Удалить запись по Id.
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => await _srv.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
