using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core
{
    public interface IAnswerService
    {
        public Task<PostAnswer> CreateAnswerForPostAsync(Guid postId, PostAnswer answer, CancellationToken token = default);
        public Task DeleteAnswerAsync(Guid answerId, CancellationToken token = default);
        public Task UpVoteAsync(Guid answerId, CancellationToken token = default);
        public Task DownVoteAsync(Guid answerId, CancellationToken token = default);
    }
}
