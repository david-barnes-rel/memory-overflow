using AutoMapper;
using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Core
{
    public class PostCommentService : IPostCommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostCommentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PostComment> CreateCommentAsync(PostComment postComment, CancellationToken token = default)
        {
            var dbModel = _mapper.Map<Data.Models.PostComment>(postComment);
            var user =await _dbContext.Users.FirstAsync(token);
            dbModel.UserId = user.Id;
            await _dbContext.PostComments.AddAsync(dbModel);
            await _dbContext.SaveChangesAsync(token);
            postComment.Id = dbModel.Id;
            return postComment;
        }

        public async Task DeleteCommentAsync(Guid postId, Guid commentId, CancellationToken token = default)
        {
            _dbContext.PostComments.Remove(new Data.Models.PostComment
            {
                Id = commentId
            });
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
