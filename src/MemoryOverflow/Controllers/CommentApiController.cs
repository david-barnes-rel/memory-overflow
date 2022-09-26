using AutoMapper;
using MemoryOverflow.Core;
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        private readonly IPostCommentService _commentService;
        private readonly IMapper _mapper;

        public CommentApiController(IPostCommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("post/{postId}/comment")]
        public async Task<IActionResult> CreatePostCommentAsync(Guid postId, Comment comment, CancellationToken token)
        {
            var domainModel = _mapper.Map<Core.Models.PostComment>(comment);
            domainModel.PostId = postId;
            await _commentService.CreateCommentAsync(domainModel, token);
            comment.Id = domainModel.Id;
            return Created("", comment);
        }

        [HttpDelete]
        [Route("post/{postId}/comment/{commentId}")]
        public async Task<IActionResult> DeletePostCommentAsync(Guid postId, Guid commentId, CancellationToken token)
        {
            await _commentService.DeleteCommentAsync(postId, commentId, token);
            return Accepted();
        }

    }
}
