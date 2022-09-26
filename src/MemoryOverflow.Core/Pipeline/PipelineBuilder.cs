using MemoryOverflow.Core.Models;
using MemoryOverflow.Core.Pipeline.Filters;

namespace MemoryOverflow.Core.Pipeline
{
    public class PipelineBuilder : IPipelineBuilder<TelemetryEvent>
    {
        private List<IFilter> _filters = new List<IFilter>();
        public void Add(IFilter filter)
        {
            _filters.Add(filter);
        }

        public void Run(TelemetryEvent @event)
        {
            foreach (var filter in _filters)
            {
                if (filter.CanRun(@event))
                {
                    filter.Run(@event);
                }
            }
        }
    }
}
