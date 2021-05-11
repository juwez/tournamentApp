using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.PlayerDto;

namespace TournamentApp.WebApi.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDtoBase>().ReverseMap();
        }
    }
}