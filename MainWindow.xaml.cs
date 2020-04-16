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

        public MainWindow()
        {
            /* GetCharacters();
             InitializeComponent();

             PersonList.ItemsSource = GoodCharacters;
             PersonList1.ItemsSource = BadCharacters;
             Biography_Frame.Visibility = Visibility.Collapsed;*/

            AsynchronousLoading();
            //Init();
            /*Task t1 = new Task(DoInit);
            Task t2 = new Task(Continue);
            t2.Start();
            t1.Start();
            t1.Wait();
            t2.Wait();
            Task t3 = new Task(Finish);
            t3.Start();
            t3.Wait();*/
            /*this.Dispatcher.Invoke(() =>
            {
                GetCharacters();
            });
            this.Dispatcher.Invoke(() =>
            {
                DoInit();
            });*/
        }

        private void Finish()
        {
            PersonList.ItemsSource = GoodCharacters;
            PersonList1.ItemsSource = BadCharacters;
            Biography_Frame.Visibility = Visibility.Collapsed;
        }

        private void Continue()
        {
            GetCharacters();
        }

        private void DoInit()
        {
            InitializeComponent();
            PersonList.ItemsSource = GoodCharacters;
            PersonList1.ItemsSource = BadCharacters;
            Biography_Frame.Visibility = Visibility.Collapsed;
        }

        public void AsynchronousLoading()
        {
            BackgroundWorker worker = new BackgroundWorker(); // Voir tuto wpf Backgroundworker
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_GetChar;
            worker.DoWork += worker_DoInit;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void worker_GetChar(object sender, DoWorkEventArgs e)
        {
            GetCharacters();
            
            Thread.Sleep(1);
        }

        private void worker_DoInit(object sender, DoWorkEventArgs e)
        {
            InitializeComponent();
            
            Thread.Sleep(1);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PersonList.ItemsSource = GoodCharacters;
            PersonList1.ItemsSource = BadCharacters;
            Biography_Frame.Visibility = Visibility.Collapsed;
            MessageBox.Show("Completed");
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBox.Show("Loading, please wait");
        }


        public void Init()
        {
            var threadInitComp = new ThreadStart(OnInitThreadStart);
            var threadLoadChar = new ThreadStart(LoadCharacters);
            var threads = new List<Thread>
            {
                new Thread(threadLoadChar),
                new Thread(threadInitComp)
            };
            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());
        }

        private void LoadCharacters()
        {
            GetCharacters();
        }

        private void OnInitThreadStart()
        {
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
            Button currentButton = (Button)sender;

            Biography_Frame.Visibility = Visibility.Visible;
            Character currentCharacter = (Character) currentButton.DataContext;
            Biography_Frame.Content = new CharacterBiography(currentCharacter);
        }

        private void OnMouseLeave_Info(object sender, MouseEventArgs e)
        {
            Biography_Frame.Visibility = Visibility.Collapsed;
        }
    }
}
