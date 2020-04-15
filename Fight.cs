using System;
using System.Collections.Generic;
using System.Text;

namespace Hackathon2
{
    public class Fight
    {
        public Character Player1 { get; set; }
        public Character Player2 { get; set; }
        public Character Winner { get; set; }

        public Fight(Character player1, Character player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public Character GetFirstPlayer()
        {
            if(Player1.powerstats.Speed < Player2.powerstats.Speed)
            {
                return Player2;
            }
            else
            {
                return Player1;
            }
        }

        public Character GetSecondPlayer()
        {
            if (Player1.powerstats.Speed < Player2.powerstats.Speed)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }

        public int GetNumberOfAttackPerTurn(Character attacker, Character defender)
        {
            int attackerPoints = attacker.powerstats.Speed * (attacker.powerstats.Intelligence + attacker.powerstats.Combat);
            int defenderPoints = defender.powerstats.Speed * (defender.powerstats.Intelligence + defender.powerstats.Combat);
            int numberAttack = Convert.ToInt32(Math.Round((double)attackerPoints / defenderPoints));

            if(numberAttack > 5)
            {
                numberAttack = 5;
            }
            else if(numberAttack < 1)
            {
                numberAttack = 1;
            }
            return numberAttack;
        }

        public Character Fighting()
        {
            Character attacker = GetFirstPlayer();
            Character defender = GetSecondPlayer();
            
            while (attacker.PV > 0 && defender.PV > 0)
            {
                if (UserAttackChoice() == "Physical Attack")
                {
                    int numberOfAttack = GetNumberOfAttackPerTurn(attacker, defender);
                    for (int i = 1; i <= numberOfAttack; i++)
                    {
                        attacker.PhysicalAttack(defender);
                    }
                }
                else if (UserAttackChoice() == "Intellectual Attack")
                {
                    attacker.IntellectualAttack(defender);
                }

                if(defender.PV <= 0)
                {
                    Winner = attacker;
                }

                Character tempCharacter = attacker;
                attacker = defender;
                defender = tempCharacter;
            }
            return Winner;
        }

        public string UserAttackChoice()
        {
            string choice = "";
            // valeur du Bouton
            return choice;
        }
    }
}
