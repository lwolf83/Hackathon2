using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon2
{
    public class Character
    {
        public string Response { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Powerstats Powerstats { get; set; }
        public int PV { get; set; }
        public Biography Biography { get; set; }
        public Appearance Appearance { get; set; }
        public Work Work { get; set; }
        public Connections Connections { get; set; }
        public Image Image { get; set; }
        public int PVmax { get; set; }

        public void Init()
        {
            PV = Powerstats.Durability * Powerstats.Combat;
            PVmax = Powerstats.Durability * Powerstats.Combat;

        }

        public int PhysicalAttack(Character defender)
        {
            int attack = (this.Powerstats.Strength + this.Powerstats.Power) * this.Powerstats.Combat;
            int defense = (defender.Powerstats.Combat) * (defender.Powerstats.Durability) + defender.Powerstats.Power;

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

            if (defender.Powerstats.Intelligence < (this.Powerstats.Intelligence + (random.NextDouble() * 0.9) * this.Powerstats.Intelligence))
            {
                int attack = (this.Powerstats.Strength + this.Powerstats.Power) * this.Powerstats.Intelligence;
                int defense = (defender.Powerstats.Intelligence) * (defender.Powerstats.Durability) + defender.Powerstats.Power;

                int damages = Convert.ToInt32(Math.Round(((double)attack / defense)) * random.NextDouble())*random.Next(10,50);
                defender.PV = defender.PV - damages;

                List<int> powerstatsList = new List<int>();
                powerstatsList.Add(defender.Powerstats.Intelligence);
                powerstatsList.Add(defender.Powerstats.Power);
                powerstatsList.Add(defender.Powerstats.Strength);
                powerstatsList.Add(defender.Powerstats.Speed);
                powerstatsList.Add(defender.Powerstats.Combat);

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
