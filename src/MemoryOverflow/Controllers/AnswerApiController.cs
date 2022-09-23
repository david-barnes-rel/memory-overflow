using AutoMapper;
using MemoryOverflow.Core;
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api")]
    [ApiController]
    public class AnswerApiController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        private readonly IAnswerCommentService _commentService;

        public AnswerApiController(IAnswerService answerService, IAnswerCommentService commentService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
            _commentService = commentService;
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
            var domainModel = _mapper.Map<Core.Models.AnswerComment>(comment);
            domainModel.AnswerId = answerId;
            var result = await _commentService.CreateCommentAsync(domainModel, token);
            comment.Id = result.Id;
            return Created("", comment);
        }

        [HttpPost]
        [Route("post/{postId}/answer/{answerId}/vote")]
        public async Task<IActionResult> VoteOnAnswerAsync(Guid postId, Guid answerId, MessageVote vote, CancellationToken token)
        {
            if (vote.Vote > 0)
            {
                await _answerService.UpVoteAsync(answerId, token);
            }
            else if (vote.Vote < 0)
            {
                await _answerService.DownVoteAsync(answerId, token);
            }
            return Accepted();
        }

        [HttpDelete]
        [Route("post/{postId}/answer/{answerId}/comment/{commentId}")]
        public async Task<IActionResult> DeleteAnswerCommentAsync(Guid postId, Guid answerId, Guid commentId, CancellationToken token)
        {
            await _commentService.DeleteCommentAsync(answerId, commentId, token);
            return Accepted();
        }
    }
}
