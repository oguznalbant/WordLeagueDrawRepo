using System.Text.Json.Serialization;

namespace Adesso.WordLeague.DTO
{
    public class DrawDto
    {
        [JsonPropertyName("user")]
        public UserDto User { get; set; }

        [JsonPropertyName("groups")]
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}
