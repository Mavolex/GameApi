using AutoMapper;
using GameSecurityLayer.Models.Items;
using GameSecurityLayer.Models.Player;

namespace GameApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemModel, ItemModelDto>();
            CreateMap<ItemModelDto, ItemModel>();

            CreateMap<PlayerModel, PlayerModelDto>();
            CreateMap<PlayerModelDto, PlayerModel>();
        }
    }
}
