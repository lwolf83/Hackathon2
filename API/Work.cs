using Newtonsoft.Json;

namespace Hackathon2
{
    public class Work
    {
        public string Occupation { get; set; }
        [JsonProperty("base")]
        public string WorkBase { get; set; }
    }
    }
