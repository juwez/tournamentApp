using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.Tournament;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Code
{
    public class TournamentService  : CrudService<TournamentDtoBase, Tournament>,
        ITournamentService
    {
        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper) 
            : base(tournamentRepository, mapper)
        {
            
        }
    }
}