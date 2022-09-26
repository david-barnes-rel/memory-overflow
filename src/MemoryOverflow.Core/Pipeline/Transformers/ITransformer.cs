using MemoryOverflow.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryOverflow.Core.Pipeline.Transformers
{
    public interface ITransformer
    {
        public void Run(TelemetryEvent @event);
    }
}
