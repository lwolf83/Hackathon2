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
        public Character Joueur1 { get; set; }
        public Character Joueur2 { get; set; }
        public Fight Fight { get; set; }

        public FightArena()
        {
            InitializeComponent();
            Joueur1 = ApiRequest.GetCharacter(58);
            Joueur1.Init();
            Joueur2 = ApiRequest.GetCharacter(97);
            Joueur2.Init();
            Player1_Image.Source = new BitmapImage(new Uri(Joueur1.image.Url));
            Player1_Name.Content = Joueur1.name;
            Player2_Image.Source = new BitmapImage(new Uri(Joueur2.image.Url));
            Player2_Name.Content = Joueur2.name;
            PV1.Content = Joueur1.PV;
            PV2.Content = Joueur2.PV;
            AQuiLeTour.Content = Joueur1.name + " vs " + Joueur2.name;
            Fight = new Fight(Joueur1, Joueur2);

        }

        public static  void GetActionJoueur1(Character character)
        {

        }

        private void J1_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            PlayerAttack(Joueur1, Joueur2, "Physical Attack");
            PV2.Content = Joueur2.PV;

        }



        private void J1_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            PlayerAttack(Joueur1, Joueur2, "Intellectual Attack");
            PV2.Content = Joueur2.PV;


        }

        private void J2_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            PlayerAttack(Joueur2, Joueur1, "Physical Attack");
            PV1.Content = Joueur1.PV;
        }

        private void J2_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            PlayerAttack(Joueur2, Joueur1, "Intellectual Attack");
            PV1.Content = Joueur1.PV;
        }

        private void PlayerAttack(Character player1, Character player2, string attacjType)
        {
            UserAttackChoice attackChoice = new UserAttackChoice();
            attackChoice.attackingPlayer = player1;
            attackChoice.defenderPlayer = player2;
            attackChoice.playerAttackType = attacjType;
            Fight.SetUserAttackChoice(attackChoice);
            

            //AQuiLeTour.Content = "J1 = " + player1.PV + " J2 = " + player2.PV;
            if (Fight.Winner != null)
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
