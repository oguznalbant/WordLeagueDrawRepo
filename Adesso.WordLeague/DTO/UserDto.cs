using System.Text.Json.Serialization;

namespace Adesso.WordLeague.DTO
{
    public class UserDto
    {
        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonPropertyName("surname")]
        public string LastName { get; set; }
    }
}
