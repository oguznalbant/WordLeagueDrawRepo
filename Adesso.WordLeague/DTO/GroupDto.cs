using System.Text.Json.Serialization;

namespace Adesso.WordLeague.DTO
{
    public class GroupDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("teams")]
        public List<TeamDto> Teams { get; set; } = new List<TeamDto>();
    }
}
