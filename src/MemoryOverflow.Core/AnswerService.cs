using AutoMapper;
using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Core
{
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
            var commentIds = await _dbContext.AnswerComments.Where(x => x.AnswerId == answerId).Select(x => x.Id).ToListAsync(token);
            _dbContext.AnswerComments.RemoveRange(commentIds.Select(x => new Data.Models.AnswerComment
            {
                Id = x
            }).ToList());
            await _dbContext.SaveChangesAsync(token);
            _dbContext.Answers.Remove(new Data.Models.Answer
            {
                Id = answerId
            });
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DownVoteAsync(Guid answerId, CancellationToken token = default)
        {
            var vote = await _dbContext.Answers.Where(x => x.Id == answerId).Select(x => x.VoteCount).SingleOrDefaultAsync(token);
            var entity = new Data.Models.Answer
            {
                Id = answerId,
                VoteCount = vote - 1
            };
            _dbContext.Answers.Attach(entity);
            _dbContext.Entry(entity).Property(x => x.VoteCount).IsModified = true;
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpVoteAsync(Guid answerId, CancellationToken token = default)
        {
            var vote = await _dbContext.Answers.Where(x => x.Id == answerId).Select(x => x.VoteCount).SingleOrDefaultAsync(token);
            var entity = new Data.Models.Answer
            {
                Id = answerId,
                VoteCount = vote + 1
            };
            _dbContext.Answers.Attach(entity);
            _dbContext.Entry(entity).Property(x => x.VoteCount).IsModified = true;
            await _dbContext.SaveChangesAsync(token);
        }
    }
}
