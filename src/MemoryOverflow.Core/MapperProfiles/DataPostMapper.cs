using AutoMapper;

namespace MemoryOverflow.Core.MapperProfiles
{
    internal class DataPostMapper : Profile
    {
        public DataPostMapper() : base("data.post")
        {
            CreateMap<Data.Models.Post, Core.Models.Post>();
            CreateMap<Core.Models.Post, Data.Models.Post>();

            
            CreateMap<Data.Models.PostComment, Core.Models.PostComment>();
            CreateMap<Core.Models.PostComment, Data.Models.PostComment>();
            CreateMap<Data.Models.Answer, Core.Models.PostAnswer>();
            CreateMap<Core.Models.PostAnswer, Data.Models.Answer>();


            CreateMap<Data.Models.User, Core.Models.User>();

            CreateMap<Data.Models.AnswerComment, Core.Models.AnswerComment>();
            CreateMap<Core.Models.AnswerComment, Data.Models.AnswerComment>();
        }
    }
}
