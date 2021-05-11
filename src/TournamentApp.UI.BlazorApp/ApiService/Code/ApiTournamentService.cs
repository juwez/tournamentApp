using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TournamentApp.UI.BlazorApp.ApiRequests;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;
using TournamentApp.UI.BlazorApp.ViewModels.TournamentRound;

namespace TournamentApp.UI.BlazorApp.ApiService.Code
{
    public class ApiTournamentService : IApiTournamentService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly JsonSerializerOptions jsonOptions;

        public ApiTournamentService(HttpClient client, IMapper mapper)
        {
            _httpClient = client;
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            _mapper = mapper;
        }
        
        public async Task<GetTournamentViewModel> GetTournament(string key)
        {
            ApiRequest<GetTournamentViewModel> apiRequest = new ApiRequest<GetTournamentViewModel>();
            return await apiRequest.GetItemFromApi($"{key}", _mapper, _httpClient, jsonOptions);
        }

        public async Task<List<GetAllTournamentViewModel>> GetTournaments()
        {
            ApiRequest<GetAllTournamentViewModel> apiRequest = new ApiRequest<GetAllTournamentViewModel>();
            return await apiRequest.GetListFromAPI("", _mapper, _httpClient, jsonOptions); 
        }

        public async Task DeleteTournament(string key)
        {
            ApiRequest<object> apiRequest = new ApiRequest<object>();
            await apiRequest.DeleteItemFromApi($"{key}", _mapper, _httpClient);
        }

        public Task<BaseTournamentViewModel> UpdateTournament(string key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> CreateTournament(CreateTournamentViewModel model)
        {
            ApiRequest<CreateTournamentViewModel> apiRequest = new ApiRequest<CreateTournamentViewModel>();
            return await apiRequest.PostObjectToServer(String.Empty, _mapper,_httpClient, model);
        }
        
    }
}
