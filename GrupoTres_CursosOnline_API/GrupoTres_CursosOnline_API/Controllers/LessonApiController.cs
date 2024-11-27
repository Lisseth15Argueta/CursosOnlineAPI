using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonApiController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonApiController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        // GET: api/lessons
        [HttpGet]
        public async Task<ActionResult<List<Lesson>>> GetAllAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            return Ok(lessons);
        }

        // GET api/lessons/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetSingleLesson(string id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(lesson);
        }

        // POST api/lessons
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Lesson lesson)
        {
            await _lessonRepository.AddLesson(lesson);
            return CreatedAtAction(nameof(GetSingleLesson), new { id = lesson.Id }, lesson);
        }

        // PUT api/lessons/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Lesson lessonEdited, string id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            await _lessonRepository.UpdateAsync(lessonEdited, id);
            return Ok(lessonEdited);
        }

        // DELETE api/lessons/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            await _lessonRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
