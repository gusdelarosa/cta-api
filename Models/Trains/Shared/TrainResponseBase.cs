using System;
using Newtonsoft.Json;

namespace CTAAPIWrapper.Models
{
    public abstract class TrainResponseBase
    {
        [JsonProperty("errCd")]
        public int ErrorCode { get; set; }

        [JsonProperty("errNm")]
        public string ErrorDecription { get; set; }

        [JsonProperty("tmst")]
        public DateTime UpdatedOn { get; set; }              
    }
}