using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryOverflow.Core.MapperProfiles
{
    internal class DataPostMapper : Profile
    {
        public DataPostMapper() : base("data.post", (ipe) => ipe.CreateMap<Data.Models.Post, Core.Models.Post>()) { }
    }
}
