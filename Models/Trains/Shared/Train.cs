using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class Train
    {
        [JsonProperty("rn")]
        public int RunNumber { get; set; }

        [JsonProperty("desSt")]
        public int DestinationStation { get; set; }

        [JsonProperty("destNm")]
        public string DestinationDescription { get; set; }

        [JsonProperty("trDr")]
        public int TrainRouteDirection { get; set; }
    }
}