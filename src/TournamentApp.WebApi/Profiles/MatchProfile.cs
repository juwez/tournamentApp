using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Match;

namespace TournamentApp.WebApi.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDtoBase>().ReverseMap();
        }
    }
}