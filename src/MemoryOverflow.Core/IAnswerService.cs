using AutoMapper;
using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Core
{
    public interface IAnswerService
    {
        public Task<PostAnswer> CreateAnswerForPostAsync(Guid postId, PostAnswer answer, CancellationToken token = default);
        public Task DeleteAnswerAsync(Guid answerId, CancellationToken token = default);
    }

    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AnswerService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PostAnswer> CreateAnswerForPostAsync(Guid postId, PostAnswer answer, CancellationToken token = default)
        {
            var dbModel = _mapper.Map<Data.Models.Answer>(answer);
            dbModel.PostId = postId;
            var user = await _dbContext.Users.FirstAsync(token);
            dbModel.UserId = user.Id;
            await _dbContext.AddAsync(dbModel, token);
            await _dbContext.SaveChangesAsync(token);
            answer.Id = dbModel.Id;
            answer.User = _mapper.Map<Core.Models.User>(dbModel.User);
            return answer;
        }

        public async Task DeleteAnswerAsync(Guid answerId, CancellationToken token = default)
        {
            _dbContext.Answers.Remove(new Data.Models.Answer
            {
                Id = answerId
            });
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
