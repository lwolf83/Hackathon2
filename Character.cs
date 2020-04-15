using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon2
{
    public class Character
    {
        public string response { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Powerstats powerstats { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }

    }
}
