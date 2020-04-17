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
using System.Linq;

namespace Hackathon2
{
    public partial class FightArena : UserControl
    {
        public List<Character> Team1 { get; set; } = new List<Character>();
        public List<Character> Team2 { get; set; } = new List<Character>();
        public Fight CurrentFight { get; set; }
        public Character SelectedCharacterT1 { get; set; }
        public Character SelectedCharacterT2 { get; set; }
        private string _nameTeam1;
        private string _nameTeam2;

        public FightArena(List<Character> team1, List<Character> team2)
        {
            InitializeComponent();
            Team1 = team1;
            Team2 = team2;
            Team1.ForEach(x => x.Init());
            Team2.ForEach(x => x.Init());
            Team1.Select(x => x.Name).ToList().ForEach(x => _nameTeam1 += "\n" + x + "\n");
            Team2.Select(x => x.Name).ToList().ForEach(x => _nameTeam2 += "\n" + x + "\n");

            SelectedCharacterT1 = Team1[0];
            Player1_Image.Source = new BitmapImage(new Uri(SelectedCharacterT1.Image.Url));
            Player1_Name.Content = SelectedCharacterT1.Name;

            SelectedCharacterT2 = Team2[0];

            Player2_Image.Source = new BitmapImage(new Uri(SelectedCharacterT2.Image.Url));
            Player2_Name.Content = SelectedCharacterT2.Name;

            Team1_ListBox.ItemsSource = Team1;
            Team1_ListBox.SelectedItem = SelectedCharacterT1;
            Team2_ListBox.ItemsSource = Team2;
            Team2_ListBox.SelectedItem = SelectedCharacterT2;

            PV1.Content = SelectedCharacterT1.PV;
            PV2.Content = SelectedCharacterT2.PV;

            PvBar_Player1.Maximum = SelectedCharacterT1.PVmax;
            PvBar_Player1.Value = SelectedCharacterT1.PV;

            PvBar_Player2.Maximum = SelectedCharacterT2.PVmax;
            PvBar_Player2.Value = SelectedCharacterT2.PV;

            CurrentFight = new Fight(Team1, Team2);
            ActivatePlayingTeam();
            AQuiLeTour.Text = SelectedCharacterT1.Name + " vs "  + SelectedCharacterT2.Name;
        }

        private void J1_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = SelectedCharacterT1;
            Character defender = SelectedCharacterT2;
            PlayerAttack(attacker, defender, "Physical Attack");
            PV2.Content = SelectedCharacterT2.PV;
            PvBar_Player2.Value = SelectedCharacterT2.PV;

        }

        private void J1_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = SelectedCharacterT1;
            Character defender = SelectedCharacterT2;
            PlayerAttack(attacker, defender, "Intellectual Attack");
            PV2.Content = SelectedCharacterT2.PV;
            PvBar_Player2.Value = SelectedCharacterT2.PV;

        }

        private void J2_AttPhys_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = SelectedCharacterT2; 
            Character defender = SelectedCharacterT1;
            PlayerAttack(attacker, defender, "Physical Attack");
            PV1.Content = SelectedCharacterT1.PV;
            PvBar_Player1.Value = SelectedCharacterT1.PV;
        }

        private void J2_AttInt_Btn(object sender, RoutedEventArgs e)
        {
            Character attacker = SelectedCharacterT2;
            Character defender = SelectedCharacterT1;
            PlayerAttack(attacker, defender, "Intellectual Attack");
            PV1.Content = SelectedCharacterT1.PV;
            PvBar_Player1.Value = SelectedCharacterT1.PV;
        }

        private void PlayerAttack(Character player1, Character player2, string attacjType)
        {
            UserAttackChoice attackChoice = new UserAttackChoice();
            attackChoice.attackingPlayer = player1;
            attackChoice.defenderPlayer = player2;
            attackChoice.playerAttackType = attacjType;

            CurrentFight.PlayerAttacks(attackChoice);
            RemoveCharacter();

            if (CurrentFight.WinnerTeam != null)
            {
                DisplayWinner();
            }
            ActivatePlayingTeam();

        }

        private void RemoveCharacter()
        {
            if(SelectedCharacterT1.PV<=0)
            {
                Team1_ListBox.ItemsSource = null;
                Team1_ListBox.ItemsSource = Team1;
                if (Team1.Count > 0)
                {
                    SelectedCharacterT1 = Team1[0];
                    Team1_ListBox.SelectedItem = SelectedCharacterT1;
                    Player1_Image.Source = new BitmapImage(new Uri(SelectedCharacterT1.Image.Url));
                    Player1_Name.Content = SelectedCharacterT1.Name;
                    PV1.Content = SelectedCharacterT1.PV;
                    PvBar_Player1.Maximum = SelectedCharacterT1.PVmax;
                    PvBar_Player1.Value = SelectedCharacterT1.PV;
                    AQuiLeTour.Text = SelectedCharacterT1.Name + " vs " + SelectedCharacterT2.Name;
                }
            }
            else if (SelectedCharacterT2.PV <= 0)
            {
                Team2_ListBox.ItemsSource = null;
                Team2_ListBox.ItemsSource = Team2;
                if (Team2.Count > 0)
                {
                    SelectedCharacterT2 = Team2[0];
                    Team2_ListBox.SelectedItem = SelectedCharacterT2;
                    Player2_Image.Source = new BitmapImage(new Uri(SelectedCharacterT2.Image.Url));
                    Player2_Name.Content = SelectedCharacterT2.Name;
                    PV2.Content = SelectedCharacterT2.PV;
                    PvBar_Player2.Maximum = SelectedCharacterT2.PVmax;
                    PvBar_Player2.Value = SelectedCharacterT2.PV;
                    AQuiLeTour.Text = SelectedCharacterT1.Name + " vs " + SelectedCharacterT2.Name;
                }
            }
        }

        private void ActivatePlayingTeam()
        {
            if (CurrentFight.isTeamOnePlaying)
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
            WinnerMessage.Text = "The Winners Team : \n";
            if(Team1.Count>0)
            {
                WinnerMessage.Text += _nameTeam1;
                Player2_Image.Source = new BitmapImage(new Uri("https://www.123-stickers.com/3766-3888-large/Array.jpg"));
                
            }
            else
            {
                WinnerMessage.Text += _nameTeam2;
                Player1_Image.Source = new BitmapImage(new Uri("https://www.123-stickers.com/3766-3888-large/Array.jpg"));
                
            }
        }

        private void DisabledPlayerOne()
        {
            J1P.IsEnabled = false;
            J1I.IsEnabled = false;
        }

        private void EnabledPlayerTwo()
        {
            J2P.IsEnabled = true;
            J2I.IsEnabled = true;
        }

        private void DisabledPlayerTwo()
        {
            J2P.IsEnabled = false;
            J2I.IsEnabled = false;

        }

        private void EnabledPlayerOne()
        {
            J1P.IsEnabled = true;
            J1I.IsEnabled = true;
        }

        private void Team1_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Team1.Count>0)
            {
                if ((Character)Team1_ListBox.SelectedItem == null)
                {
                    SelectedCharacterT1 = Team1[0];
                }
                else
                {
                    ListBoxItem selectedItem = ((sender as ListBox).SelectedItem as ListBoxItem);
                    SelectedCharacterT1 = (Character)Team1_ListBox.SelectedItem;
                }
                Player1_Image.Source = new BitmapImage(new Uri(SelectedCharacterT1.Image.Url));
                Player1_Name.Content = SelectedCharacterT1.Name;
                PV1.Content = SelectedCharacterT1.PV;
                PvBar_Player1.Maximum = SelectedCharacterT1.PVmax;
                PvBar_Player1.Value = SelectedCharacterT1.PV;
                AQuiLeTour.Text = SelectedCharacterT1.Name + " vs " + SelectedCharacterT2.Name;
            }
        }

        private void Team2_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Team2.Count > 0)
            {
                if ((Character)Team2_ListBox.SelectedItem == null)
                {
                    SelectedCharacterT2 = Team2[0];
                }
                else
                {
                    ListBoxItem selectedItem = ((sender as ListBox).SelectedItem as ListBoxItem);
                    SelectedCharacterT2 = (Character)Team2_ListBox.SelectedItem;
                }
                Player2_Image.Source = new BitmapImage(new Uri(SelectedCharacterT2.Image.Url));
                Player2_Name.Content = SelectedCharacterT2.Name;
                PV2.Content = SelectedCharacterT2.PV;
                PvBar_Player2.Maximum = SelectedCharacterT2.PVmax;
                PvBar_Player2.Value = SelectedCharacterT2.PV;
                AQuiLeTour.Text = SelectedCharacterT1.Name + " vs " + SelectedCharacterT2.Name;
                
            }
        }
    }
}
