using ObuvnayaFabrika.Model;
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
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }
        private static int unsuccesful = 0;
        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client());
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtlogin.Text.Trim();
            string password = BoxPassword.Password.Trim();
            if (login.Length > 0 && password.Length > 0)
            {
                if (unsuccesful < 1)
                {
                    var User = Helper.GetContext().Authorizacia.Where(t => t.Login == login && t.Parol == password).FirstOrDefault();
                    if (User != null)
                    {
                        
                    }
                    else
                    {
                        unsuccesful++;
                        MessageBox.Show("Пользователь с таким логином не найден", "Внимание", MessageBoxButton.OK);
                        GetCaptcha();
                    }
                }
                else
                {
                    string captca = txtboxCaptcha.Text;
                    var User = Helper.GetContext().Authorizacia.Where(t => t.Login == login && t.Parol == password).FirstOrDefault();
                    if (User != null && captca == txtBlockCaptcha.Text)
                    {
                    
                    }
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private  void GetCaptcha()
        {
            txtboxCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;
            Random random = new Random();
            int RandNum = random.Next(0, 3);
            switch(RandNum)
            {
                case 1:
                    TextBlock.Ca
                    break;
            }
        }
    }
}
