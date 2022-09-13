
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostApiController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync(CancellationToken token)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(SlimPost post,CancellationToken token)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id:string}/vote")]
        public async Task<IActionResult> VoteOnPostAsync(Guid id, MessageVote vote, CancellationToken token)
        {
            return Accepted();
        }

        [HttpGet]
        [Route("{id:string}")]
        public async Task<IActionResult> GetPostDetailAsync(Guid id, CancellationToken token)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("{id:string}")]
        public async Task<IActionResult> UpdatePostAsync(Guid id, SlimPost post, CancellationToken token)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id:string}")]
        public async Task<IActionResult> DeletePostAsync(Guid id, CancellationToken token)
        {
            return Ok();
        }

    }
}
