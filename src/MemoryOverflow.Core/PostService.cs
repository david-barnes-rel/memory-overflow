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
    internal class PostService : IPostService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Post> CreateAsync(Post post, CancellationToken token = default)
        {
            var dbPost = _mapper.Map<Data.Models.Post>(post);
            var user = await _dbContext.Users.FirstAsync(token);
            dbPost.UserId = user.Id;
            await _dbContext.AddAsync(dbPost);
            await _dbContext.SaveChangesAsync();
            post.Id = dbPost.Id;
            return post;
        }

        public async Task DeletePostAsync(Guid postId, CancellationToken token = default)
        {
            _dbContext.Posts.Remove(new Data.Models.Post
            {
                Id = postId
            });
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DownVoteAsync(Guid postId, CancellationToken token = default)
        {
            var vote = await _dbContext.Posts.Where(x => x.Id == postId).Select(x => x.VoteCount).SingleOrDefaultAsync(token);
            var post = new Data.Models.Post
            {
                Id = postId,
                VoteCount = vote - 1
            };
            _dbContext.Posts.Attach(post);
            _dbContext.Entry(post).Property(x => x.VoteCount).IsModified = true;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(CancellationToken token = default)
        {
            var posts = await _dbContext.Posts.ToListAsync(token);
            var domainPosts = _mapper.Map<IReadOnlyList<Data.Models.Post>, IReadOnlyList<Post>>(posts);
            return domainPosts;
        }

        public async Task<Post> GetPostAsync(Guid postId, CancellationToken token = default)
        {
            var post = await _dbContext.Posts
                .Include(x => x.User)
                .Include(x => x.Answers)
                .Include(x => x.Comments)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == postId, token);
            var domainPost = _mapper.Map<Core.Models.Post>(post);
            return domainPost;

        }

        public async Task UpVoteAsync(Guid postId, CancellationToken token = default)
        {
            var vote = await _dbContext.Posts.Where(x => x.Id == postId).Select(x => x.VoteCount).SingleOrDefaultAsync(token);
            var post = new Data.Models.Post
            {
                Id = postId,
                VoteCount = vote + 1
            };
            _dbContext.Posts.Attach(post);
            _dbContext.Entry(post).Property(x => x.VoteCount).IsModified = true;
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
