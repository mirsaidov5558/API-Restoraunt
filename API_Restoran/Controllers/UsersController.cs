using API_Restoran.DTOs.UserDTOs;
using API_Restoran.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET /api/users
        [HttpGet]                                // HTTP‑метод GET
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync(); // сервис возвращает DTO
            return Ok(users);                         // 200 OK + JSON
        }


        // GET /api/users/5
        [HttpGet("{id:int}")]                       // GET c параметром id
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id); // ищем
            if (user is null) return NotFound();        // 404, если нет
            return Ok(user);                            // 200 + DTO
        }

        // POST /api/users
        [HttpPost]                                    // HTTP‑метод POST
        public async Task<ActionResult<UserDto>> Create(CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto); // создаём
            return CreatedAtAction(nameof(GetById),     // 201 Created + Location
                                   new { id = user.Id }, user);
        }

        // PUT /api/users/5
        [HttpPut("{id:int}")]                         // HTTP‑метод PUT
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto); // обновление
            if (user is null) return NotFound();            // 404
            return Ok(user);                                // 200 OK + обновлённый объект
        }

        // DELETE /api/users/5
        [HttpDelete("{id:int}")]                      // HTTP‑метод DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _userService.DeleteAsync(id); // удаляем
            if (!removed) return NotFound();              // 404, если нет
            return NoContent();                           // 204 NoContent
        }
    }
}
