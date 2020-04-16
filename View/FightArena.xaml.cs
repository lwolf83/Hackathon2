using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hackathon2
{
    /// <summary>
    /// Logique d'interaction pour FightArena.xaml
    /// </summary>
    public partial class FightArena : UserControl
    {
        public List<Character> Team1 { get; set; }
        public List<Character> Team2 { get; set; }
        public Fight Fight { get; set; }

        public FightArena()
        {
            InitializeComponent();
            Team1 = new List<Character>();
            Team1.Add(ApiRequest.GetCharacter(58));
            Team1.ForEach(x => x.Init());
            Team2 = new List<Character>();
            Team2.Add(ApiRequest.GetCharacter(69));
            Team2.ForEach(x => x.Init());
            Fight = new Fight(Team1, Team2);
            AQuiLeTour.Content = "J1 = " + Team1[0].PV + " J2 = " + Team2[0].PV;
        }

        public static  void GetActionJoueur1(Character character)
        {

        }

        private void J1_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = Team1[0];
            Character defender = Team2[0];
            PlayerAttack(attacker, defender, "Physical Attack");
        }



        private void J1_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = Team1[0];
            Character defender = Team2[0];
            PlayerAttack(attacker, defender, "Intellectual Attack");

        }

        private void J2_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = Team2[0]; 
            Character defender = Team1[0];
            PlayerAttack(attacker, defender, "Physical Attack");

        }

        private void J2_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = Team2[0];
            Character defender = Team1[0];
            PlayerAttack(attacker, defender, "Intellectual Attack");

        }

        private void PlayerAttack(Character player1, Character player2, string attacjType)
        {
            UserAttackChoice attackChoice = new UserAttackChoice();
            attackChoice.attackingPlayer = player1;
            attackChoice.defenderPlayer = player2;
            attackChoice.playerAttackType = attacjType;
            Fight.PlayerAttacks(attackChoice);
            AQuiLeTour.Content = "J1 = " + Team1[0].PV + " J2 = " + Team2[0].PV;
            if (Fight.WinnerTeam != null)
            {
                DisplayWinner();
            }
            if(Fight.isTeamOnePlaying)
            {
                EnabledPlayerOne();
                DisabledPlayerTwo();
            }
            else
            {
                EnabledPlayerTwo();
                DisabledPlayerOne();
            }
        }

        private void DisplayWinner()
        {
           
        }

        private void DisabledPlayerOne()
        {
          
        }

        private void EnabledPlayerTwo()
        {
          
        }

        private void DisabledPlayerTwo()
        {
           
        }

        private void EnabledPlayerOne()
        {
          
        }
    }
}
