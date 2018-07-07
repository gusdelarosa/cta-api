

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class ArrivalsResponse
    {
        [JsonProperty("eta")]
        public IEnumerable<ETA> ETAs { get; set; }        
    }
}