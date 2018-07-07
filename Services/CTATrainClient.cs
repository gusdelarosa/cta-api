using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CTAAPIWrapper.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace  CTAAPIWrapper.Services
{
    public class CTATrainClient : ICTATrainClient
    {
        private HttpClient Client { get; set; }
        private string BaseAddress { get => "http://lapi.transitchicago.com/api/1.0/";}

        private string Token;

        public CTATrainClient(HttpClient httpClient, IConfiguration configuration)
        {
            httpClient.BaseAddress = new Uri(this.BaseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));     
            Client = httpClient;
            Token = configuration["TrainAPIKey"];
        }

        private async Task<TResponse> GetAsync<TRequest, TResponse> (TRequest request) where TRequest : CTARequestBase
        {
            request.Token = Token;
            var requestQuery = $"{this.BaseAddress}{request.Endpoint}{request.QueryString}";
            var response = await Client.GetAsync(requestQuery);
            
            var responseString = await response.Content.ReadAsStringAsync();
            var deserializedResponse =  JsonConvert.DeserializeObject<ResponseContainer<TResponse>>(responseString);

            return deserializedResponse.CTAReponse;
        }

        public Task<ArrivalsResponse> GetTrainArrivals(int id)
        {
            var arrivalRequest = new ArrivalsRequest();

            if (id > 39999)
            {
                arrivalRequest.StopId = id.ToString();
            }
            else
            {
                    arrivalRequest.StationId = id.ToString();   
            }

            return GetAsync<ArrivalsRequest, ArrivalsResponse>(arrivalRequest);
        }

        public Task<FollowTrainResponse> FollowTrain(int id)
        {
            var followTrainRequest = new FollowTrainRequest();
            return GetAsync<FollowTrainRequest, FollowTrainResponse>(followTrainRequest);
        }

        public Task<LocationsResponse> GetTrainLocations(string color)
        {
            var trainLines = string.IsNullOrEmpty(color) ? GetAllTrainLinesName() : new List<string>{color};
            var locationRequest = new LocationsRequest()
            {                
                TrainRoutes = trainLines,
            };

            return GetAsync<LocationsRequest, LocationsResponse>(locationRequest);
        }

        private List<string> GetAllTrainLinesName()
        {
            return new List<string>
            {
                "Red",
                "Blue",
                "Brn",
                "G",
                "Org",
                "P",
                "Pink",
                "Y",
            };

        }
    }
}