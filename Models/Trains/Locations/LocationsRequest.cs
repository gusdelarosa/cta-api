

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class LocationsRequest : CTARequestBase
    {
        [Required]
        [JsonProperty("rt")]
        public IEnumerable<string> TrainRoutes { get; set; }
        public override string Endpoint { get { return "/ttpositions.aspx/?key=" + this.Token + "&"; } }
    }
}