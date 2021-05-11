using System.Linq;
using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.RoundsDto;

namespace TournamentApp.WebApi.Profiles
{
    public class RoundsProfile : Profile
    {
        public RoundsProfile()
        {
            CreateMap<Round, RoundDtoBase>().ReverseMap();
        }
    }
}