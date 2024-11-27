using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseApiController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseApiController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return Ok(courses);
        }

        // GET api/courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetSingleCourse(string id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/courses
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Course course)
        {
            await _courseRepository.AddCourse(course);
            return CreatedAtAction(nameof(GetSingleCourse), new { id = course.Id }, course);
        }

        // PUT api/courses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Course courseEdited, string id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course is null)
            {
                return NotFound();
            }
            await _courseRepository.UpdateAsync(courseEdited, id);
            return Ok(courseEdited);
        }

        // DELETE api/courses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course is null)
            {
                return NotFound();
            }
            await _courseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
