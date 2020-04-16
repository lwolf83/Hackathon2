using System;
using System.Collections.Generic;
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
        public List<Character> Characters { get; set; } = new List<Character>();

        public MainWindow()
        {
            InitializeComponent();
            GetCharacters();
            PersonList.ItemsSource = Characters;
            PersonList1.ItemsSource = Characters;
        }

        public void GetCharacters()
        {
            int i = 1;
            Character character = ApiRequest.GetCharacter(i);

            while (i < 7)
            {
                Characters.Add(character);
                i++;
                character = ApiRequest.GetCharacter(i);
            }
        }
    }
}
