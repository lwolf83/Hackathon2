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
    /// Logique d'interaction pour SelectCharacters.xaml
    /// </summary>
    public partial class SelectCharacters : UserControl
    {
        public SelectCharacters()
        {
            InitializeComponent();
        }

        private void OnMouseEnter_Info(object sender, MouseEventArgs e)
        {
            Button currentButton = (Button)sender;

            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            Frame Biography_Frame = (Frame)mainWindow.FindName("Biography_Frame");
            Biography_Frame.Visibility = Visibility.Visible;

            Character currentCharacter = (Character)currentButton.DataContext;
            Biography_Frame.Content = new CharacterBiography(currentCharacter);
        }

        private void OnMouseLeave_Info(object sender, MouseEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            Frame Biography_Frame = (Frame)mainWindow.FindName("Biography_Frame");
            Biography_Frame.Visibility = Visibility.Collapsed;
        }
    }
}
