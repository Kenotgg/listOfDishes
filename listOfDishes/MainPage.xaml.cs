using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        static string connectionString = @"Data Source=DESKTOP-932LPHA\SQLEXPRESS;Initial Catalog=Restaraunt;Integrated Security=True";
        public MainPage()
        {
            InitializeComponent();
            PageController.DishCreationPage.ClearFields();
            DataContext db = new DataContext(connectionString);
            Table<Dishes> dishes = db.GetTable<Dishes>();

            MainListBox.ItemsSource = dishes;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            using (DataContext db = new DataContext(connectionString))
            {

                if (MainListBox.SelectedItem is Dishes)
                {

                    var selectedDish = (Dishes)MainListBox.SelectedItem;
                    var dishListLinedWithDish = db.GetTable<DishList>().Where(dl => dl.DishID == selectedDish.ID);
                    foreach (var dishList in dishListLinedWithDish)
                    {
                        db.GetTable<DishList>().DeleteOnSubmit((DishList)dishList);
                        db.SubmitChanges();
                    }

                    var dishToDelete = db.GetTable<Dishes>().FirstOrDefault(d => d.ID == selectedDish.ID);
                    MessageBox.Show("Удалено " + dishToDelete.Title);
                    db.GetTable<Dishes>().DeleteOnSubmit(dishToDelete);
                    db.SubmitChanges();
                    MainListBox.ItemsSource = db.GetTable<Dishes>();




                }


            }

        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.DishCreationPage, UriKind.Relative);
        }
    }
}
