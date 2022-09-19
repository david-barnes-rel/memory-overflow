﻿
using AutoMapper;
using MemoryOverflow.Core;
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostApiController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPostsAsync(CancellationToken token)
        {
            var posts = await _postService.GetAllPostsAsync(token);
            var modelPosts = _mapper.Map<IReadOnlyList<Core.Models.Post>, IReadOnlyList<Models.SlimPost>>(posts);
            return Ok(modelPosts);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(SlimPost post,CancellationToken token)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/vote")]
        public async Task<IActionResult> VoteOnPostAsync(Guid id, MessageVote vote, CancellationToken token)
        {
            return Accepted();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostDetailAsync(Guid id, CancellationToken token)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePostAsync(Guid id, SlimPost post, CancellationToken token)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePostAsync(Guid id, CancellationToken token)
        {
            return Ok();
        }

    }
}