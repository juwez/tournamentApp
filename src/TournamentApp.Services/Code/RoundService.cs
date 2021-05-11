using AutoMapper;
using TournamentApp.Model;
using TournamentApp.Repository;
using TournamentApp.Services.Dtos.RoundsDto;
using TournamentApp.Services.Interfaces;

namespace TournamentApp.Services.Code
{
    public class RoundService : CrudService<RoundDtoBase, Round>, IRoundService
    {
        public RoundService(IRoundRepository repository, IMapper mapper) : base(repository, mapper)
        {
            
        }
    }
}