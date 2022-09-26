using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using MemoryOverflow.Data.Models.Telemetry;

namespace MemoryOverflow.Core.Pipeline.Transformers
{
    public class PostTransformer : ITransformer
    {
        private readonly ApplicationDbContext _dbContext;

        public PostTransformer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Run(TelemetryEvent @event)
        {
            var dbModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PostTelemetry>(@event.Payload);
            _dbContext.PostTelemetry.Add(dbModel);
            _dbContext.SaveChanges();
        }
    }
}
