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
    /// Logique d'interaction pour FightArena.xaml
    /// </summary>
    public partial class FightArena : UserControl
    {
        public FightArena()
        {
            InitializeComponent();
            Character Joueur1 = ApiRequest.GetCharacter(58);
            Joueur1.Init();
            Character Joueur2 = ApiRequest.GetCharacter(97);
            Joueur2.Init();

            Fight fight = new Fight(Joueur1, Joueur2);
            fight.Fighting();
        }

        public static  void GetActionJoueur1(Character character)
        {

        }

    }
}
