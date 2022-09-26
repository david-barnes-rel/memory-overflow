using MemoryOverflow.Core.Models;

namespace MemoryOverflow.Core.Pipeline.Filters
{
    public class CommentFilter : AbstractFilter
    {
        public override bool CanRun(TelemetryEvent @event)
        {
            return @event.Type == "create_comment";
        }
    }
}
