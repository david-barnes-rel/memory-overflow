using MemoryOverflow.Core.Models;
using MemoryOverflow.Core.Pipeline.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Core.Pipeline.Filters
{
    public interface IFilter
    {
        public bool CanRun(TelemetryEvent @event);
        public void Add(ITransformer transformer);
        public void Run(TelemetryEvent @event);
    }
}
