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

namespace Hackathon2
{
    /// <summary>
    /// Logique d'interaction pour CharacterBiography.xaml
    /// </summary>
    public partial class CharacterBiography : Page
    {
        public CharacterBiography(Character currentCharacter)
        {
            InitializeComponent();
            //Character currentCharacter = ApiRequest.GetCharacter(70)
            DataContext = currentCharacter;
        }

    }
}
