using AutoMapper;
using MemoryOverflow.Core;
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api")]
    [ApiController]
    public class AnswerApiController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public AnswerApiController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("post/{postId}/answer")]
        public async Task<IActionResult> CreateAnswerAsync(Guid postId, Answer answer, CancellationToken token)
        {
            var domainAnswer = _mapper.Map<Core.Models.PostAnswer>(answer);
            var createdAnswer = await _answerService.CreateAnswerForPostAsync(postId, domainAnswer, token);
            return Created($"post/{postId}/answer/{createdAnswer.Id}", createdAnswer);
        }

        [HttpDelete]
        [Route("post/{postId}/answer/{answerId}")]
        public async Task<IActionResult> DeleteAnswerAsync(Guid postId, Guid answerId, CancellationToken token)
        {
            await _answerService.DeleteAnswerAsync(answerId, token);
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
