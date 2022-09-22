using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core
{

    public interface IPostService
    {
        public Task<IReadOnlyList<Post>> GetAllPostsAsync(CancellationToken token = default);
        public Task<Post> GetPostAsync(Guid postId, CancellationToken token = default);
        public Task DeletePostAsync(Guid postId, CancellationToken token = default);

        public Task<Post> CreateAsync(Post post, CancellationToken token = default);
        public Task UpVoteAsync(Guid postId, CancellationToken token = default);
        public Task DownVoteAsync(Guid postId, CancellationToken token = default);
    }
}
