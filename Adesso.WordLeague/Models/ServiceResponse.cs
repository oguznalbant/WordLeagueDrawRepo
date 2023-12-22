using Newtonsoft.Json;

namespace Adesso.WordLeague.Models
{
    public class ServiceResponse<T>
        where T : class
    {
        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; } = false;

        [JsonProperty("ErrorCode", NullValueHandling = NullValueHandling.Ignore)]
        public int? ErrorCode { get; set; }

        [JsonProperty("Message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("Data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}
