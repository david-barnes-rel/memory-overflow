using AutoMapper;
using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Core
{
    public interface IPostService
    {
        public Task<IReadOnlyList<Post>> GetAllPostsAsync(CancellationToken token = default);
    }
    internal class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(CancellationToken token = default)
        {
            var posts = await _dbContext.Posts.ToListAsync(token);
            var domainPosts = _mapper.Map<IReadOnlyList<Data.Models.Post>, IReadOnlyList<Post>>(posts);
            return domainPosts;
        }
    }
}
