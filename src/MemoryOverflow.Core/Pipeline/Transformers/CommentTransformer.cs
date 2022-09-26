using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using MemoryOverflow.Data.Models.Telemetry;

namespace MemoryOverflow.Core.Pipeline.Transformers
{
    public class CommentTransformer : ITransformer
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentTransformer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Run(TelemetryEvent @event)
        {
            var dbModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentTelemetry>(@event.Payload);
            _dbContext.CommentTelemetry.Add(dbModel);
            _dbContext.SaveChanges();
        }
    }
}
