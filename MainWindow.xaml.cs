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
        public MainWindow()
        {
            InitializeComponent();
            Character test = ApiRequest.GetCharacter(58);
            //CharacterPicture.Picture.Source = new BitmapImage(
            //new Uri(test.image.Url, UriKind.Absolute));

            List<Person> persons = new List<Person>() {
                new Person() { Name = "John", Image = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"},
                new Person() { Name = "John", Image = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"},
                new Person() { Name = "John", Image = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"},
                new Person() { Name = "John", Image = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"},
                new Person() { Name = "John", Image = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"}
            };
            PersonList.ItemsSource = persons;
            PersonList1.ItemsSource = persons;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
