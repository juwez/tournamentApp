using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TournamentApp.UI.BlazorApp.ApiRequests
{
    public class ApiRequest<VM>
    {
        
        public async Task<VM> GetItemFromApi(string endpoint, IMapper mapper, HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(apiResponse);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(apiResponse);
                var jsonToSerialize =
                    JsonSerializer.Deserialize<VM>(apiResponse, jsonSerializerOptions);

                VM viewModelToReturn = mapper.Map<VM>(jsonToSerialize);
                
                return viewModelToReturn;
                
            }

            throw new Exception($"Something went wrong while getting the tournament with the following key: {endpoint}");

        }

        public async Task<List<VM>> GetListFromAPI(string endpoint, IMapper mapper, HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var jsonToSerialize =
                    JsonSerializer.Deserialize<List<VM>>(apiResponse, jsonSerializerOptions);

                List<VM> viewModelToReturn = mapper.Map<List<VM>>(jsonToSerialize);

                return viewModelToReturn;

            }

            throw new Exception("Something went wrong while getting the tournaments");

        }
        
        public async Task<bool> DeleteItemFromApi(string endpoint, IMapper mapper, HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(endpoint);
            if (response.IsSuccessStatusCode) { return true; }
            throw new Exception("Something went wrong while deleting the tournaments");
        }
        
        public async Task<bool> PostObjectToServer(string endpoint, IMapper mapper, HttpClient http, VM viewModel)
        {
            VM newDto = mapper.Map<VM>(viewModel);
            HttpContent content = new StringContent(JsonSerializer.Serialize(newDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(endpoint, content);
            Console.WriteLine(content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(HttpStatusCode.Created);
            return true;
        }
        
        public async Task<bool> PostObjectListToServer(string endpoint, IMapper mapper, HttpClient http, List<VM> viewmodeList)
        {
           
            List<VM> newDtoList = mapper.Map<List<VM>>(viewmodeList);
            HttpContent content = 
                new StringContent(JsonSerializer.Serialize(newDtoList), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PostAsync(endpoint, content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Somthing went wrong while posting the request");
            }

            return true;
        }
        
        public async Task<VM> PutObjectToServer(string endpoint, IMapper mapper, HttpClient http, VM viewModel)
        {
           
            VM newDto = mapper.Map<VM>(viewModel);
            HttpContent content = 
                new StringContent(JsonSerializer.Serialize(newDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PutAsync(endpoint, content);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Somthing went wrong while posting the request");
            }

            return newDto;
        }
        public async Task<VM> PatchObjectToServer(string endpoint, IMapper mapper, HttpClient http, VM viewModel)
        {
           
            VM newDto = mapper.Map<VM>(viewModel);
            HttpContent content = 
                new StringContent(JsonSerializer.Serialize(newDto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PatchAsync(endpoint, content);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Somthing went wrong while patching the update");
            }

            return newDto;
        }






    }
}
