
using AutoMapper;

namespace MemoryOverflow.MapperProfiles
{
    public class PostMapper : Profile
    {
        public PostMapper():base("test", (ipe)=>ipe.CreateMap<Core.Models.Post, Models.SlimPost>())
        {
        }
    }
}
