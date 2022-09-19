using MemoryOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api")]
    [ApiController]
    public class AnswerApiController : ControllerBase
    {

        [HttpPost]
        [Route("post/{postId}/answer")]
        public async Task<IActionResult> CreateAnswerAsync(Guid postId, Answer answer, CancellationToken token)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("post/{postId}/answer/{answerId}")]
        public async Task<IActionResult> CreateAnswerAsync(Guid postId, Guid answerId, CancellationToken token)
        {
            return Accepted();
        }

        [HttpPost]
        [Route("post/{postId}/answer/{answerId}/comment")]
        public async Task<IActionResult> CreateAnswerCommentAsync(Guid postId, Guid answerId, Comment comment, CancellationToken token)
        {
            return Accepted();
        }

        [HttpPost]
        [Route("post/{postId}/answer/{answerId}/vote")]
        public async Task<IActionResult> CreateAnswerCommentAsync(Guid postId, Guid answerId, MessageVote vote, CancellationToken token)
        {
            return Accepted();
        }

        [HttpDelete]
        [Route("post/{postId}/answer/{answerId}/comment/{commentId}")]
        public async Task<IActionResult> DeleteAnswerCommentAsync(Guid postId, Guid answerId, Guid commentId, CancellationToken token)
        {
            return Accepted();
        }
    }
}
