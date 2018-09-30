

using System;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class ETA : Train
    {
        [JsonProperty("staId")]
        public int StationId { get; set; }

        [JsonProperty("stpId")]
        public int StopId { get; set; }

        [JsonProperty("staNm")]
        public string StopName { get; set; }

        [JsonProperty("stpDe")]
        public string StopDescription { get; set; }

        [JsonProperty("rt")]
        public string RouteName { get; set; }

        [JsonProperty("arrT")]
        public DateTime AttivalTime { get; set; }

        [JsonProperty("isApp")]
        public byte IsApproaching { get; set; }

        [JsonProperty("isDly")]
        public byte IsDelayed { get; set; }

        [JsonProperty("isSch")]
        public byte IsBasedOnSchedule { get; set; }

        [JsonProperty("lat")]
        public decimal? Latitude { get; set; }

        [JsonProperty("lon")]
        public decimal? Longitude { get; set; }

        [JsonProperty("heading")]
        public int? DegreesDirection { get; set; }

        private int TimeInMinutes { get { return (AttivalTime - DateTime.Now).Minutes; } }
    }
}