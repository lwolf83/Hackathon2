using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hackathon2
{
    public class Fight
    {
        public List<Character> Team1 { get; set; }
        public List<Character> Team2 { get; set; }
        public List<Character> WinnerTeam { get; set; }
        private UserAttackChoice _UserAttackChoice = new UserAttackChoice();
        public bool isTeamOnePlaying { get; set; }

        public Fight(List<Character> team1, List<Character> team2)
        {
            Team1 = team1;
            Team2 = team2;
            isTeamOnePlaying = GetFirstPlayer();
        }

        public bool GetFirstPlayer()
        {
            int speedSumTeam1 = 0;
            Team1.ForEach(x => speedSumTeam1 += x.Powerstats.Speed + speedSumTeam1);
            int speedSumTeam2 = 0;
            Team1.ForEach(x => speedSumTeam2 += x.Powerstats.Speed + speedSumTeam2);

            if (speedSumTeam1 < speedSumTeam2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PlayerAttacks(UserAttackChoice userAttackChoice)
        {
            _UserAttackChoice = userAttackChoice;
            Attack(userAttackChoice.attackingPlayer, userAttackChoice.defenderPlayer);
            if (userAttackChoice.IsDefenderDead())
            {
                DefenderDies(userAttackChoice.defenderPlayer);
            }
            else
            {
                isTeamOnePlaying = !isTeamOnePlaying;
            }
        }

        public void Attack(Character attacker, Character defender)
        {
            if (_UserAttackChoice.playerAttackType == "Physical Attack")
            {
                int numberOfAttack = GetNumberOfAttackPerTurn(attacker, defender);
                for (int i = 1; i <= numberOfAttack; i++)
                {
                    attacker.PhysicalAttack(defender);
                }
            }
            else if (_UserAttackChoice.playerAttackType == "Intellectual Attack")
            {
                attacker.IntellectualAttack(defender);
            }
        }

        public int GetNumberOfAttackPerTurn(Character attacker, Character defender)
        {
            int attackerPoints = attacker.Powerstats.Speed * (attacker.Powerstats.Intelligence + attacker.Powerstats.Combat);
            int defenderPoints = defender.Powerstats.Speed * (defender.Powerstats.Intelligence + defender.Powerstats.Combat);
            int numberAttack = Convert.ToInt32(Math.Round((double)attackerPoints / defenderPoints));

            if (numberAttack > 5)
            {
                numberAttack = 5;
            }
            else if (numberAttack < 1)
            {
                numberAttack = 1;
            }
            return numberAttack;
        }

        public void DefenderDies(Character defender)
        {
            if (Team1.Contains(defender))
            {
                Team1.Remove(defender);
                if (Team1.Count <= 0)
                {
                    WinnerTeam = Team2;
                }
            }
            if (Team2.Contains(defender))
            {
                Team2.Remove(defender);
                if (Team2.Count <= 0)
                {
                    WinnerTeam = Team1;
                }
            }
        }


        /*public string UserAttackChoice(UserAttackChoice userAttack)
        {
            FightArena.GetActionJoueur1(character);
            string choice = "";
            // valeur du Bouton
            return choice;
        }*/
    }
}
