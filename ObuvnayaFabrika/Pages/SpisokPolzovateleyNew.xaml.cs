using ObuvnayaFabrika.models;
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
    /// Логика взаимодействия для SomePage.xaml
    /// </summary>
    public partial class SomePage : Page
    {
        List<Sotrudniki> sotr;
        public SomePage()
        {
            InitializeComponent();
            sotr = Helper.GetContext().Sotrudniki.ToList();
            LbSpisok.ItemsSource = sotr;
           cmb_filter.SelectedIndex = 0;
            cmb_filter2.SelectedIndex = 0;
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int ind = LbSpisok.SelectedIndex;
            int kod_sotrudnika = sotr[ind].KodSotrudnika;
            TecushiyPolzovatel tecushiyPolzovatel = new TecushiyPolzovatel(kod_sotrudnika);
            this.NavigationService.Navigate(tecushiyPolzovatel);
            //this.NavigationService.Navigate(new Uri("Pages/TecushiyPolzovatel.xaml", UriKind.Relative));
        }
        private void btn_sort_Click(object sender, RoutedEventArgs e)
        { 
            sotr = Helper.GetContext().Sotrudniki.Where(t => t.Imia.Contains(txt_filter.Text) || t.Familia.Contains(txt_filter.Text)||t.Familia.Contains(txt_filter.Text)).ToList();
           
            if(cmb_filter.Text == "По возрастанию")
            {
                if (cmb_filter2.Text == "По имени")
                {
                    sotr.OrderByDescending(t => t.Imia);
                }
                if(cmb_filter2.Text == "По фамилии")
                {
                    sotr.OrderByDescending(t => t.Familia);
                }    
            }
            if (cmb_filter.Text == "По убыванию")
            {
                if (cmb_filter2.Text == "По имени")
                {
                    sotr.OrderByDescending(t => t.Imia);
                }
                if (cmb_filter2.Text == "По фамилии")
                {
                    sotr.OrderByDescending(t => t.Familia);
                }
                sotr.Reverse();
            }
            LbSpisok.ItemsSource = sotr;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            sotr = Helper.GetContext().Sotrudniki.ToList();
            LbSpisok.ItemsSource = sotr;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TecushiyPolzovatel.xaml", UriKind.Relative));
        }
    }
}
