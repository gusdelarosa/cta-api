using System.Collections.Generic;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class Route
    {
        [JsonProperty("@name")]
        public string LineColor { get; set; }

        [JsonProperty("train")]
        public List<Train> Trains { get; set; }
    }
}