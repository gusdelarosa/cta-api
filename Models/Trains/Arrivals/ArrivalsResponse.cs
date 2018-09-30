

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class ArrivalsResponse : TrainResponseBase
    {
        [JsonProperty("eta")]
        public IEnumerable<ETA> ETAs { get; set; }
    }
}