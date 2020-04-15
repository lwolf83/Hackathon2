using Newtonsoft.Json;

namespace Hackathon2
{
    public class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }
        public string Relatives { get; set; }
    }
}
