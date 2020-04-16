using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Hackathon2
{
    public class Powerstats
    {
        [JsonProperty("Intelligence")]
        private string Intel { get; set; }
        [JsonProperty("Strength")]
        private string Stren { get; set; }
        [JsonProperty("Speed")]
        private string Spee { get; set; }
        [JsonProperty("Durability")]
        private string Durab { get; set; }
        [JsonProperty("Power")]
        private string Pow { get; set; }
        [JsonProperty("Combat")]
        private string Comb { get; set; }

        [JsonIgnore]
        public int Intelligence { get { return getValue(Intel); } set { } }
        [JsonIgnore]
        public int Strength { get { return getValue(Stren); }  set { } }
        [JsonIgnore]
        public int Speed { get { return getValue(Spee); } set { } }
        [JsonIgnore]
        public int Durability { get { return getValue(Durab); } set { } }
        [JsonIgnore]
        public int Power { get { return getValue(Pow); } set { } }
        [JsonIgnore]
        public int Combat { get { return getValue(Comb); } set { } }


        public int getValue(string value)
        {
            Random random = new Random();
            int newCaract = random.Next(75, 100);
            return (value == "null") ? newCaract : Convert.ToInt32(value);
        }

    }
}
