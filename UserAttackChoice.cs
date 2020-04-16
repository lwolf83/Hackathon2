using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon2
{
    public class UserAttackChoice
    {
        public Character attackingPlayer { get; set; }
        public Character defenderPlayer { get; set; }
        public string playerAttackType { get; set; }

        public bool IsDefenderDead()
        {
            if (defenderPlayer.PV <= 0)
            { return true; }
            return false;
        }
    }


}
