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
        [Route("post/{postId:string}/answer")]
        public async Task<IActionResult> CreateAnswerAsync(Guid postId, Answer answer, CancellationToken token)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("post/{postId:string}/answer/{answerId:string}")]
        public async Task<IActionResult> CreateAnswerAsync(Guid postId, Guid answerId, CancellationToken token)
        {
            return Accepted();
        }

        [HttpPost]
        [Route("post/{postId:string}/answer/{answerId:string}/comment")]
        public async Task<IActionResult> CreateAnswerCommentAsync(Guid postId, Guid answerId, Comment comment, CancellationToken token)
        {
            return Accepted();
        }

        [HttpPost]
        [Route("post/{postId:string}/answer/{answerId:string}/vote")]
        public async Task<IActionResult> CreateAnswerCommentAsync(Guid postId, Guid answerId, MessageVote vote, CancellationToken token)
        {
            return Accepted();
        }

        [HttpDelete]
        [Route("post/{postId:string}/answer/{answerId:string}/comment/{commentId:string}")]
        public async Task<IActionResult> DeleteAnswerCommentAsync(Guid postId, Guid answerId, Guid commentId, CancellationToken token)
        {
            return Accepted();
        }
    }
}
