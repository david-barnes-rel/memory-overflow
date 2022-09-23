using AutoMapper;
using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Core
{
    public class AnswerCommentService : IAnswerCommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AnswerCommentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AnswerComment> CreateCommentAsync(AnswerComment comment, CancellationToken token = default)
        {
            var dbModel = _mapper.Map<Data.Models.AnswerComment>(comment);
            var user = await _dbContext.Users.FirstAsync(token);
            dbModel.UserId = user.Id;
            await _dbContext.AnswerComments.AddAsync(dbModel,token);
            await _dbContext.SaveChangesAsync(token);
            comment.Id = dbModel.Id;
            return comment;
        }

        public async Task DeleteCommentAsync(Guid answerId, Guid commentId, CancellationToken token = default)
        {
            _dbContext.AnswerComments.Remove(new Data.Models.AnswerComment
            {
                Id = commentId
            });
            await _dbContext.SaveChangesAsync(token); 
        }
    }
}
