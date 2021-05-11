using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using TournamentApp.UI.BlazorApp.ApiRequests;
using TournamentApp.UI.BlazorApp.ApiService.Interfaces;
using TournamentApp.UI.BlazorApp.ViewModels.Players;
using TournamentApp.UI.BlazorApp.ViewModels.Tournament;

namespace TournamentApp.UI.BlazorApp.ApiService.Code
{
    public class ApiPlayerService : IApiPlayerService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        private readonly JsonSerializerOptions jsonOptions;

        public ApiPlayerService(HttpClient client, IMapper mapper)
        {
            _httpClient = client;
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            _mapper = mapper;
        }
        
        public async Task<List<BasePlayerViewModel>> GetAllPlayers()
        {
            ApiRequest<BasePlayerViewModel> request = new ApiRequest<BasePlayerViewModel>();
            return await request.GetListFromAPI("", _mapper, _httpClient, jsonOptions);
        }

        public async Task<bool> AddPlayer(BasePlayerViewModel viewModel)
        {   
            ApiRequest<BasePlayerViewModel> request = new ApiRequest<BasePlayerViewModel>();
            return await request.PostObjectToServer("", _mapper, _httpClient, viewModel);
        }

        public async Task<bool> DeletePlayer(string key)
        {
            ApiRequest<BasePlayerViewModel> request = new ApiRequest<BasePlayerViewModel>();
            return await request.DeleteItemFromApi($"{key}", _mapper, _httpClient);
        }

        public async Task<BasePlayerViewModel> GetPlayer(string key)
        {
            ApiRequest<BasePlayerViewModel> request = new ApiRequest<BasePlayerViewModel>();
            return await request.GetItemFromApi($"{key}", _mapper, _httpClient, jsonOptions);
        }
    }
}