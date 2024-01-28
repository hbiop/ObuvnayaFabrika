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

namespace ObuvnayaFabrika.Pages
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Page
    {

        public admin(string Fio)
        {
            InitializeComponent();
            getTime(label, Fio);
            
        }
 
        private static void getTime(Label label, string Fio)
        {
            if(DateTime.Now.Hour  < 12)
            {
                label.Content = "Доброе утро,  " + Fio;
            }
            if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 17)
            {
                label.Content = "Доброе день,  " + Fio;
            }
            if (DateTime.Now.Hour >= 17)
            {
                label.Content = "Доброе вечер,  " + Fio;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/SpisokPolzovateley.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/SpisokPolzovateleyNew.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TecushiyPolzovatel.xaml", UriKind.Relative));
        }
    }
    
}
