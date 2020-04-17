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
using System.Threading;
using System.ComponentModel;

namespace Hackathon2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Character> GoodCharacters { get; set; } = new List<Character>();
        public List<Character> BadCharacters { get; set; } = new List<Character>();

        private Mutex _mut = new Mutex();
        private int cpt = 0;

        public List<Character> GoodTeam { get; set; } = new List<Character>();
        public List<Character> BadTeam { get; set; } = new List<Character>();

        private object content;

        public MainWindow()
        {
            InitializeComponent();
            Biography_Frame.Visibility = Visibility.Collapsed;

            while (GoodCharacters.Count < 9 || BadCharacters.Count < 9)
            {
                List<Thread> getCharactersList = new List<Thread>();
                for (int i = 0; i < 5; i++)
                {
                    Thread getCharacter = new Thread(new ThreadStart(GetCharacters));
                    getCharactersList.Add(getCharacter);
                    getCharacter.Start();
                }
                getCharactersList.ForEach(t => t.Join());
            }

            GoodCharacter.PersonList.ItemsSource = GoodCharacters;
            BadCharacter.PersonList.ItemsSource = BadCharacters;

            content = Content;
        }

        public void GetCharacters()
        {
            Random gen = new Random();
            int id;

            if (GoodCharacters.Count < 9 || BadCharacters.Count < 9)
            {
                id = gen.Next(1, 730);
                if (GoodCharacters.Where(x => Convert.ToInt32(x.Id) == id).Count() == 0 && BadCharacters.Where(x => Convert.ToInt32(x.Id) == id).Count() == 0)
                {
                    Character character = ApiRequest.GetCharacter(id);
                    _mut.WaitOne();
                    cpt++;
                    _mut.ReleaseMutex();
                    if ((character.Biography.Alignment == "good") && !GoodCharacters.Contains(character) && GoodCharacters.Count < 9)
                    {
                        _mut.WaitOne();
                        GoodCharacters.Add(character);
                        _mut.ReleaseMutex();
                    }
                    else if ((character.Biography.Alignment == "bad") && (!BadCharacters.Contains(character) && BadCharacters.Count < 9))
                    {
                        _mut.WaitOne();
                        BadCharacters.Add(character);
                        _mut.ReleaseMutex();
                    }
                }
            }
        }

        private void Button_ClickGoodteam(object sender, RoutedEventArgs e)
        {
            GoodTeam = GoodCharacter.PersonList.SelectedItems.Cast<Character>().ToList();
            Button_Goodteam.Content = "Selected";
            GoodTeam = GoodCharacter.PersonList.SelectedItems.Cast<Character>().ToList();
        }

        private void Button_ClickBadteam(object sender, RoutedEventArgs e)
        {
            BadTeam = BadCharacter.PersonList.SelectedItems.Cast<Character>().ToList();
            Button_Badteam.Content = "Selected";
            BadTeam = BadCharacter.PersonList.SelectedItems.Cast<Character>().ToList();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (GoodTeam.Count.Equals(BadTeam.Count) && (BadTeam.Count != 0))
            {
                FightArena arena = new FightArena(GoodTeam, BadTeam, this);
                this.Content = arena;
            }
            else
            {
                MessageBox.Show("Read Carefully Game Rules !!! \nTeams Not Null & Equals\nMax 4 Heroes Each Team");
            }
        }
<<<<<<< HEAD

        public void GoBackToStartPage()
        {
            Content = content;
        }
=======
>>>>>>> master
    }
}
