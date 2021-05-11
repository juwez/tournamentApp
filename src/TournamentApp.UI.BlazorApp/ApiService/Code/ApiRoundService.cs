using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.UI.BlazorApp.ApiRequests;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;
using TournamentApp.UI.BlazorApp.ViewModels.RoundMatchViewModel;
using TournamentApp.UI.BlazorApp.ViewModels.Rounds;


namespace TournamentApp.UI.BlazorApp.ApiService.Code
{
    public class ApiRoundService : IApiRoundService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly JsonSerializerOptions jsonOptions;
         
        public ApiRoundService(HttpClient client, IMapper mapper)
        {
            _httpClient = client;
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            _mapper = mapper;
        }
        
        public async Task<BaseRoundViewModel> GetRound(string key)
        {
            ApiRequest<BaseRoundViewModel> apiRequest = new ApiRequest<BaseRoundViewModel>();
            return await apiRequest.GetItemFromApi($"{key}", _mapper, _httpClient, jsonOptions);
        }

        public async Task<List<BaseRoundMatchesViewModel>> GetMatchesForARound(string key)
        {
            ApiRequest<BaseRoundMatchesViewModel> apiRequest = new ApiRequest<BaseRoundMatchesViewModel>();
            return await apiRequest.GetListFromAPI($"{key}/matches", _mapper, _httpClient, jsonOptions);
        }
        

        public async Task<bool> FinishRound(string key, List<BaseRoundMatchesViewModel> matchesViewModels)
        {
            ApiRequest<BaseRoundMatchesViewModel> apiRequest = new ApiRequest<BaseRoundMatchesViewModel>();
            return await apiRequest.PostObjectListToServer($"{key}/finish", _mapper, _httpClient, matchesViewModels);
        }
    }
}