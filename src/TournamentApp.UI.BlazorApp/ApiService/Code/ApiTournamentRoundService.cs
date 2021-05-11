using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.UI.BlazorApp.ApiRequests;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.ApiService.Code
{
    public class ApiTournamentRoundService : IApiTournamentRoundService
    {
        
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly JsonSerializerOptions jsonOptions;

        public ApiTournamentRoundService(HttpClient client, IMapper mapper)
        {
            _httpClient = client;
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            _mapper = mapper;
        }
        
        public async Task<List<GetMainRoundsViewModel>> GetAllRoundsForATournamentAsync(string tournamentkey)
        {
            ApiRequest<GetMainRoundsViewModel> apiRequest = new ApiRequest<GetMainRoundsViewModel>();
            return await apiRequest.GetListFromAPI($"{tournamentkey}/rounds", _mapper, _httpClient, jsonOptions);
        }

        public async Task<List<GetMainRoundsViewModel>> GetAllRoundsIncludingSubRoundsAsync(string tournamentkey,
            string startingRoundKey)
        {
            ApiRequest<GetMainRoundsViewModel> apiRequest = new ApiRequest<GetMainRoundsViewModel>();
            return await apiRequest.GetListFromAPI($"{tournamentkey}/rounds/{startingRoundKey}", _mapper, _httpClient, jsonOptions); 
        }

        public async Task<bool> RemoveAllRoundsIncludingSubRounds(string tournamentkey, string startingRoundKey)
        {
            ApiRequest<GetMainRoundsViewModel> apiRequest = new ApiRequest<GetMainRoundsViewModel>();
            string url = $"{tournamentkey}/rounds/{startingRoundKey}";
            return await apiRequest.DeleteItemFromApi(url, _mapper,
                _httpClient);
        }
    }
}