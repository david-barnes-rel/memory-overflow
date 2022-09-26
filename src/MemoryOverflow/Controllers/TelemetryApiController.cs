using AutoMapper;
using MemoryOverflow.Core.Pipeline;
using MemoryOverflow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryOverflow.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TelemetryApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPipelineBuilder<Core.Models.TelemetryEvent> _pipeline;

        public TelemetryApiController(IPipelineBuilder<Core.Models.TelemetryEvent> pipeline, IMapper mapper)
        {
            _mapper = mapper;
            _pipeline = pipeline;
        }
        [HttpPost]
        [Route("telemetry/track")]
        public async Task<IActionResult> Track(TelemetryEvent @event, CancellationToken token)
        {
            var domainEvent = _mapper.Map<Core.Models.TelemetryEvent>(@event);
            _pipeline.Run(domainEvent);
            return Ok();
        }
    }
}
