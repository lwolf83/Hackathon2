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

        public MainWindow()
        {
            GetCharacters();
            InitializeComponent();

            PersonList.ItemsSource = GoodCharacters;
            PersonList1.ItemsSource = BadCharacters;
            Biography_Frame.Visibility = Visibility.Collapsed;
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

        private void OnMouseEnter_Info(object sender, MouseEventArgs e)
        {
            Biography_Frame.Visibility = Visibility.Visible;
            Character currentCharacter = ApiRequest.GetCharacter(70);
            Biography_Frame.Content = new CharacterBiography(currentCharacter);
        }

        private void OnMouseLeave_Info(object sender, MouseEventArgs e)
        {
            Biography_Frame.Visibility = Visibility.Collapsed;
        }
    }
}
