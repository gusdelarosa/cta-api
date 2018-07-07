

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public class FollowTrainRequest : CTARequestBase
    {
        [Required]
        [JsonProperty("runnumber")]
        public int TrainNumber { get; set; }
        public override string Endpoint { get { return "/ttfollow.aspx/?key=" + this.Token + "&"; } }
    }
}