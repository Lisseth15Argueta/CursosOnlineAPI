using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModuleApiController : Controller
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleApiController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        // GET: api/modules
        [HttpGet]
        public async Task<ActionResult<List<Module>>> GetAllAsync()
        {
            var modules = await _moduleRepository.GetAllAsync();
            return Ok(modules);
        }

        // GET api/modules/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetSingleModule(string id)
        {
            var module = await _moduleRepository.GetModuleById(id);
            if (module is null)
            {
                return NotFound();
            }
            return Ok(module);
        }

        // POST api/modules
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Module module)
        {
            await _moduleRepository.AddModule(module);
            return CreatedAtAction(nameof(GetSingleModule), new { id = module.Id }, module);
        }

        // PUT api/modules/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Module moduleEdited, string id)
        {
            var module = await _moduleRepository.GetModuleById(id);
            if (module is null)
            {
                return NotFound();
            }
            await _moduleRepository.UpdateAsync(moduleEdited, id);
            return Ok(moduleEdited);
        }

        // DELETE api/modules/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var module = await _moduleRepository.GetModuleById(id);
            if (module is null)
            {
                return NotFound();
            }
            await _moduleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
