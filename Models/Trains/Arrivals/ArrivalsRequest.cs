

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class ArrivalsRequest : CTARequestBase
    {
        [Required]
        [JsonProperty("mapid" )]
        public string StationId { get; set; }

        [Required]
        [JsonProperty("stpid")]
        public string StopId { get; set; }

        [JsonProperty("rt")]
        public string RouteId { get; set; }

        [JsonProperty("max")]
        public string MaxResults { get; set; }

        public override string Endpoint { get { return "/ttarrivals.aspx/?key=" + this.Token + "&"; } }
    }
}