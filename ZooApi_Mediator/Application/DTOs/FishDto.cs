using System.Text.Json.Serialization;

namespace ZooApi_Mediator.Application.DTOs
{
    public class FishDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
    }
}
