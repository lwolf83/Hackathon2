using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hackathon2
{
    public class Appearance
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public IList<string> Height { get; set; }
        public IList<string> Weight { get; set; }
        [JsonProperty("eye-color")]
        public string EyeColor { get; set; }
        [JsonProperty("hair-color")]
        public string HairColor { get; set; }
    }
}
