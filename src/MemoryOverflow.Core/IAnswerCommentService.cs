using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core
{
    public interface IAnswerCommentService
    {
        public Task<AnswerComment> CreateCommentAsync(AnswerComment comment, CancellationToken token = default);
        public Task DeleteCommentAsync(Guid answerId, Guid commentId, CancellationToken token = default);
    }
}
