using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Character> GoodCharacters { get; set; } = new List<Character>();
        public List<Character> BadCharacters { get; set; } = new List<Character>();
        public List<Character> GoodTeam { get; set; } = new List<Character>();
        public List<Character> BadTeam { get; set; } = new List<Character>();

        public MainWindow()
        {
            GetCharacters();
            InitializeComponent();

            PersonList.ItemsSource = GoodCharacters;
            PersonList1.ItemsSource = BadCharacters;
        }

        public void GetCharacters()
        {
            Random gen = new Random();
            int id;

            while (GoodCharacters.Count < 10 || BadCharacters.Count < 10)
            {
                id = gen.Next(1, 730);
                Character character = ApiRequest.GetCharacter(id);

                if((character.Biography.Alignment == "good") && !GoodCharacters.Contains(character) && GoodCharacters.Count < 10)
                {
                    GoodCharacters.Add(character);
                }
                else if (! BadCharacters.Contains(character) && BadCharacters.Count < 10)
                {
                    BadCharacters.Add(character);
                }
            }
        }

        private void PersonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_Goodteam.Content = "Select team";

            if (PersonList.SelectedItems.Count < 5)
            {
                GoodSelectionBadge.Badge = PersonList.SelectedItems.Count;
            }
            else
            {
                PersonList.SelectedItems.RemoveAt(4); 
            }
        }

        private void PersonList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_Badteam.Content = "Select team";

            if (PersonList1.SelectedItems.Count < 5)
            {
                BadSelectionBadge.Badge = PersonList1.SelectedItems.Count;
            }
            else
            {
                PersonList1.SelectedItems.RemoveAt(4);
            }            
        }

        private void Button_ClickGoodteam(object sender, RoutedEventArgs e)
        {
            GoodTeam = PersonList.SelectedItems.Cast<Character>().ToList();
            Button_Goodteam.Content = "Selected";
        }

        private void Button_ClickBadteam(object sender, RoutedEventArgs e)
        {
            BadTeam = PersonList1.SelectedItems.Cast<Character>().ToList();
            Button_Badteam.Content = "Selected";
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            if(GoodTeam.Count.Equals(BadTeam.Count) && (BadTeam.Count != 0))
            {
                FightArena arena = new FightArena(GoodTeam, BadTeam);
                this.Content = arena;
            }
            else
            {
                MessageBox.Show("Read Carefully Game Rules !!! \nTeams Not Null & Equals\n Max 4 Heroes Each Team");
            }
        }
    }
}
