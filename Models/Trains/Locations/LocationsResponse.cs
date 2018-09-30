using Newtonsoft.Json;
using System.Collections.Generic;

namespace CTAAPIWrapper.Models
{
    public class LocationsResponse : TrainResponseBase
    {
        [JsonProperty("route")]
        public List<Route> Routes { get; set; }
    }
}