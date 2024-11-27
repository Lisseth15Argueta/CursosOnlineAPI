using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoTres_CursosOnline_API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentApiController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApiController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllCommentsAsync();
            return Ok(comments);
        }

        // GET api/comments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetSingleComment(string id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST api/comments
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Comment comment)
        {
            await _commentRepository.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetSingleComment), new { id = comment.Id }, comment);
        }

        // PUT api/comments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Comment commentEdited, string id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            await _commentRepository.UpdateCommentAsync(commentEdited, id);
            return Ok(commentEdited);
        }

        // DELETE api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            await _commentRepository.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
