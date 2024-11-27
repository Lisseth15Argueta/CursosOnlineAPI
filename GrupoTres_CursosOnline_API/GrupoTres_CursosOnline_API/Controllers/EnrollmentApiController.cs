using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Enrollments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentApiController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentApiController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // GET: api/enrollments
        [HttpGet]
        public async Task<ActionResult<List<Enrollment>>> GetAllAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return Ok(enrollments);
        }

        // GET api/enrollments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetSingleEnrollment(string id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // POST api/enrollments
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.AddEnrollment(enrollment);
            return CreatedAtAction(nameof(GetSingleEnrollment), new { id = enrollment.Id.ToString() }, enrollment);
        }

        // PUT api/enrollments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Enrollment enrollmentEdited, string id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            await _enrollmentRepository.UpdateEnrollment(enrollmentEdited, id);
            return Ok(enrollmentEdited);
        }

        // DELETE api/enrollments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            await _enrollmentRepository.DeleteEnrollment(id);
            return NoContent();
        }
    }

}
