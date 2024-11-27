using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetSingleUser), new { id = user.Id }, user);
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(User userEdited, string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                return NotFound();
            }
            await _userRepository.UpdateAsync(userEdited, id);
            return Ok(userEdited);
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                return NotFound();
            }
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
