using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CTAAPIWrapper.Models;


namespace  CTAAPIWrapper.Services
{
    public interface ICTATrainClient
    {
        Task<ArrivalsResponse> GetTrainArrivals(int id);

        Task<FollowTrainResponse> FollowTrain(int id);

        Task<LocationsResponse> GetTrainLocations(string color = null);
    }

}