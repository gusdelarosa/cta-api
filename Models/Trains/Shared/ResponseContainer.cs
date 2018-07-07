using Newtonsoft.Json;


namespace CTAAPIWrapper.Models{
    
    public class ResponseContainer<T>
    {
        [JsonProperty("ctatt")]
        public T CTAReponse { get; set; }

        public override string ToString()
        {
            return CTAReponse.ToString();
        }
    }
}
