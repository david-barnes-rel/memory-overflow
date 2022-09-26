using MemoryOverflow.Core.Models;
using MemoryOverflow.Core.Pipeline.Transformers;

namespace MemoryOverflow.Core.Pipeline.Filters
{
    public abstract class AbstractFilter : IFilter
    {
        private List<ITransformer> _transformers = new List<ITransformer>();

        public void Add(ITransformer transformer)
        {
            _transformers.Add(transformer);
        }

        public abstract bool CanRun(TelemetryEvent @event);

        public void Run(TelemetryEvent @event)
        {
            foreach (var transformer in _transformers)
            {
                transformer.Run(@event);
            }
        }
    }
}
