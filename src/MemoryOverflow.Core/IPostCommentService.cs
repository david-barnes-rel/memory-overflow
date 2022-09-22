using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core
{
    public interface IPostCommentService
    {
        public Task<PostComment> CreateCommentAsync(PostComment postComment, CancellationToken token = default);
        public Task DeleteCommentAsync(Guid postId, Guid commentId, CancellationToken token = default);
    }
}
