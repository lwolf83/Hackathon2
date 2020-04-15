using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hackathon2
{
    public class Biography
    {
        [JsonProperty("full-name")]
        public string Fullname { get; set; }
        [JsonProperty("alter-egos")]
        public string Alteregos { get; set; }
        public IList<string> Aliases { get; set; }
        [JsonProperty("place-of-birth")]
        public string PlaceOfBirth { get; set; }
        [JsonProperty("first-appearance")]
        public string FirstAppearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }
}
    
