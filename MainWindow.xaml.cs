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

        public MainWindow()
        {
            InitializeComponent();
            Biography_Frame.Visibility = Visibility.Collapsed;

            while (GoodCharacters.Count < 10 || BadCharacters.Count < 10)
            {
                List<Thread> getCharactersList = new List<Thread>();
                for (int i = 0; i < 13; i++)
                {
                    Thread getCharacter = new Thread(new ThreadStart(GetCharacters));
                    getCharactersList.Add(getCharacter);
                    getCharacter.Start();
                }
                getCharactersList.ForEach(t => t.Join());
            }
            
            goodCharacters.PersonList.ItemsSource = GoodCharacters;
            badCharacters.PersonList.ItemsSource = BadCharacters;

        }

        public void GetCharacters()
        {
            Random gen = new Random();
            int id;

            if (GoodCharacters.Count < 10 || BadCharacters.Count < 10)
            {
                id = gen.Next(1, 730);
                if(GoodCharacters.Where(x => Convert.ToInt32(x.Id) == id).Count() == 0 && BadCharacters.Where(x => Convert.ToInt32(x.Id) == id).Count() == 0)
                { 
                    Character character = ApiRequest.GetCharacter(id);
                    _mut.WaitOne();
                    cpt++;
                    _mut.ReleaseMutex();
                    if ((character.Biography.Alignment == "good") && !GoodCharacters.Contains(character) && GoodCharacters.Count < 10)
                    {
                        _mut.WaitOne();
                        GoodCharacters.Add(character);
                        _mut.ReleaseMutex();
                    }
                    else if ((character.Biography.Alignment == "bad") && (! BadCharacters.Contains(character) && BadCharacters.Count < 10))
                    {
                        _mut.WaitOne();
                        BadCharacters.Add(character);
                        _mut.ReleaseMutex();
                    }
                }
            }
        }

    }
}
