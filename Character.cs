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
        public int PV { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }

        public void Init()
        {
            PV = powerstats.Durability * powerstats.Combat;
        }

        public int PhysicalAttack(Character defender)
        {
            int attack = (this.powerstats.Strength + this.powerstats.Power) * this.powerstats.Combat;
            int defense = (defender.powerstats.Combat) * (defender.powerstats.Durability) + defender.powerstats.Power;

            Random random = new Random();
            int coefRandom = random.Next(1, 10)*10;

            double removedPV = Math.Round(((double)attack / defense) * coefRandom);
            defender.PV = Convert.ToInt32(defender.PV - removedPV);

            return defender.PV;
        }

        public int IntellectualAttack(Character defender)
        {
            Random random = new Random();
            int coefRandom2 = random.Next(5, 10)*10;

            if (defender.powerstats.Intelligence < (this.powerstats.Intelligence + (random.NextDouble() * 0.9) * this.powerstats.Intelligence))
            {
                int attack = (this.powerstats.Strength + this.powerstats.Power) * this.powerstats.Intelligence;
                int defense = (defender.powerstats.Intelligence) * (defender.powerstats.Durability) + defender.powerstats.Power;

                int damages = Convert.ToInt32(Math.Round(((double)attack / defense)) * random.NextDouble())*random.Next(10,50);
                defender.PV = defender.PV - damages;

                List<int> powerstatsList = new List<int>();
                powerstatsList.Add(defender.powerstats.Intelligence);
                powerstatsList.Add(defender.powerstats.Power);
                powerstatsList.Add(defender.powerstats.Strength);
                powerstatsList.Add(defender.powerstats.Speed);
                powerstatsList.Add(defender.powerstats.Combat);

                int coefRandom3 = random.Next(0, 4);
                powerstatsList[coefRandom3] = powerstatsList[coefRandom3] - (damages * coefRandom2);

                return defender.PV;
            }
            else
            {
                return defender.PV;
            }
        }
    }
}
