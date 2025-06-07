using API_Restoran.DTOs.TableDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _service;

        public TablesController(ITableService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDto>>> GetAll()
        {
            var tables = await _service.GetAllAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TableDto>> Get(int id)
        {
            var table = await _service.GetByIdAsync(id);
            if (table == null) return NotFound();
            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<TableDto>> Create(CreateTableDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateTableDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
