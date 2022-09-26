using MemoryOverflow.Core.Models;
using MemoryOverflow.Data;
using MemoryOverflow.Data.Models.Telemetry;

namespace MemoryOverflow.Core.Pipeline.Transformers
{
    public class AnswerTransformer : ITransformer
    {
        private readonly ApplicationDbContext _dbContext;

        public AnswerTransformer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Run(TelemetryEvent @event)
        {
            var dbModel = Newtonsoft.Json.JsonConvert.DeserializeObject<AnswerTelemetry>(@event.Payload);
            _dbContext.AnswerTelemetry.Add(dbModel);
            _dbContext.SaveChanges();
        }
    }
}
