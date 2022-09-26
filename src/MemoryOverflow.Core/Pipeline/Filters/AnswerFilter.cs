using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core.Pipeline.Filters
{
    public class AnswerFilter : AbstractFilter
    {
        public override bool CanRun(TelemetryEvent @event)
        {
            return @event.Type == "create_answer";
        }
    }
}
