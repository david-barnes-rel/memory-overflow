using MemoryOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        [HttpPost]
        [Route("post/{postId:string}/comment")]
        public async Task<IActionResult> CreateCommentAsync(Guid postId, Comment comment, CancellationToken token)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("post/{postId:string}/comment/{commentId:string}")]
        public async Task<IActionResult> DeleteCommentAsync(Guid postId, Guid commentId, CancellationToken token)
        {
            return Ok();
        }

    }
}
