using AutoMapper;
 
namespace LiveCards.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Card, CardModel>()
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => Math.Round( src.CostUSD,2)));
            //CreateMap<List<Card>, List<CardModel>>();

            //CreateMap< List<Card>, List<CardModel>>();

        }
    }
}
