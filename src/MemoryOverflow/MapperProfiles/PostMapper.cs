
using AutoMapper;

namespace MemoryOverflow.MapperProfiles
{
    public class PostMapper : Profile
    {
        public PostMapper() : base("test")

        {
            CreateMap<Core.Models.Post, Models.SlimPost>().ForMember(x => x.Text, opt => opt.MapFrom(x => x.Question));
            CreateMap<Core.Models.Post, Models.PostDetal>().ForMember(x => x.Text, opt => opt.MapFrom(x => x.Question));
            CreateMap<Models.SlimPost, Core.Models.Post>().ForMember(x => x.Question, opt => opt.MapFrom(x => x.Text));


            CreateMap<Core.Models.PostComment, Models.Comment>().ForMember(x=>x.Message, opt=>opt.MapFrom(x=>x.Text));
            CreateMap<Models.Comment, Core.Models.PostComment>().ForMember(x=>x.Text, opt=>opt.MapFrom(x=>x.Message));

            CreateMap<Core.Models.PostAnswer, Models.Answer>();
            CreateMap<Models.Answer, Core.Models.PostAnswer>();


            CreateMap<Core.Models.AnswerComment, Models.Comment>().ForMember(x => x.Message, opt => opt.MapFrom(x => x.Text));
            CreateMap<Models.Comment, Core.Models.AnswerComment>().ForMember(x => x.Text, opt => opt.MapFrom(x => x.Message));
            CreateMap<Core.Models.User, Models.User>();
        }
    }
}

