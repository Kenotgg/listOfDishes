using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace listOfDishes
{
    /// <summary>
    /// Логика взаимодействия для DishCreationPage.xaml
    /// </summary>
    public partial class DishCreationPage : Page
    {
        static string connectionString = @"Data Source=DESKTOP-932LPHA\SQLEXPRESS;Initial Catalog=Restaraunt;Integrated Security=True";
        public DishCreationPage()
        {
            InitializeComponent();
        }

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(PageController.MainPage,UriKind.Relative);
            ClearFields();
        }

        private void OnAdd(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                var dish = new Dishes { Title = NameBox.Text, Weight = Int32.Parse(WeightBox.Text), KiloCalories = Int32.Parse(KcalBox.Text), Carbohydrates = Int32.Parse(carboBox.Text), Proteins = Int32.Parse(ProteinsBox.Text), Fats = Int32.Parse(FatsBox.Text), Status = false };
                db.GetTable<Dishes>().InsertOnSubmit(dish);
                db.SubmitChanges();
            }
        }

        public void ClearFields() 
        {
            NameBox.Text = string.Empty;
            WeightBox.Text = string.Empty;
            KcalBox.Text = string.Empty;
            carboBox.Text = string.Empty;
            ProteinsBox.Text = string.Empty;
            FatsBox.Text = string.Empty;
        }
    }
}
