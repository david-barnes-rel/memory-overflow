using MemoryOverflow.Core.Models;
using MemoryOverflow.Core.Pipeline.Filters;

namespace MemoryOverflow.Core.Pipeline
{
    public interface IPipelineBuilder<T>
    {
        public void Add(IFilter filter);
        public void Run(T @event);
    }
}
