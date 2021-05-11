using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.UI.BlazorApp.ApiRequests;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Match;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;

namespace TournamentApp.UI.BlazorApp.ApiService.Code
{
    public class ApiMatchService : IApiMatchService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly JsonSerializerOptions jsonOptions;

        public ApiMatchService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            _mapper = mapper;
        }
        
        public async Task<BaseRoundMatchesViewModel> GetMatchById(string matchKey)
        {
            ApiRequest<BaseRoundMatchesViewModel> request = new ApiRequest<BaseRoundMatchesViewModel>();
            return await request.GetItemFromApi($"{matchKey}", _mapper, _httpClient, jsonOptions);
        }
        public async Task<BaseMatchViewModel> SendScoreToApi(string matchKey, BaseMatchViewModel model)
        {
            ApiRequest<BaseMatchViewModel> request = new ApiRequest<BaseMatchViewModel>();
            return await request.PatchObjectToServer($"{matchKey}", _mapper, _httpClient, model);
        }

        public async Task<FinishMatchViewModel> FinishMatch(string matchKey, FinishMatchViewModel model)
        {
            ApiRequest<FinishMatchViewModel> request = new ApiRequest<FinishMatchViewModel>();
            return await request.PatchObjectToServer($"{matchKey}/finishMatch", _mapper, _httpClient, model);
        }
    }
}