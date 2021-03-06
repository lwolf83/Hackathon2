﻿using System;
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
using MaterialDesignThemes.Wpf;

namespace Hackathon2
{
    /// <summary>
    /// Logique d'interaction pour CharacterSelector.xaml
    /// </summary>
    public partial class CharacterSelector : UserControl
    {
        public CharacterSelector()
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

        private void PersonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            CharacterSelector GoodCharacter = (CharacterSelector) mainWindow.FindName("GoodCharacter");
            Badged GoodSelectionBadge = (Badged) mainWindow.FindName("GoodSelectionBadge");
            CharacterSelector BadCharacter = (CharacterSelector)mainWindow.FindName("BadCharacter");
            Badged BadSelectionBadge = (Badged)mainWindow.FindName("BadSelectionBadge");

            if (GoodCharacter.PersonList.SelectedItems.Count < 5)
            {
                GoodSelectionBadge.Badge = GoodCharacter.PersonList.SelectedItems.Count;
            }
            else
            {
                GoodCharacter.PersonList.SelectedItems.RemoveAt(4);
            }

            if (BadCharacter.PersonList.SelectedItems.Count < 5)
            {
                BadSelectionBadge.Badge = BadCharacter.PersonList.SelectedItems.Count;
            }
            else
            {
                BadCharacter.PersonList.SelectedItems.RemoveAt(4);
            }

        }
    }
}
