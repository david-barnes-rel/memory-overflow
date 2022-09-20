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
        public DataPostMapper() : base("data.post")
        {
            CreateMap<Data.Models.Post, Core.Models.Post>();
            CreateMap<Core.Models.Post, Data.Models.Post>();

            
            CreateMap<Data.Models.PostComment, Core.Models.PostComment>();
            CreateMap<Data.Models.Answer, Core.Models.PostAnswer>();
            CreateMap<Core.Models.PostAnswer, Data.Models.Answer>();


            CreateMap<Data.Models.User, Core.Models.User>();
        }
    }
}
