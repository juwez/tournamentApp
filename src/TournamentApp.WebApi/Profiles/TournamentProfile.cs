using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Services.Dtos.Tournament;

namespace TournamentApp.WebApi.Profiles
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentDtoBase>().ReverseMap();
            CreateMap<Tournament, GetAllTournamentsDto>();
        }
    }
}