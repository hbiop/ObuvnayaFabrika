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
    /// Логика взаимодействия для SpisokPolzovateleyReal.xaml
    /// </summary>
    public partial class SpisokPolzovateleyReal : Page
    {
        public SpisokPolzovateleyReal()
        {
            InitializeComponent();
            var Sotrudniki = Helper.GetContext().Sotrudniki.ToList();
            LViewProduct.ItemsSource = Sotrudniki;
        }
    }
}
