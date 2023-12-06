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
using Captcha;
using Hash;
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
            string password =Hash.Hash.HashPassword( BoxPassword.Password.Trim());
            if (login.Length > 0 && password.Length > 0)
            {
                if (unsuccesful < 1)
                {
                    var User = Helper.GetContext().Authorizacia.Where(t => t.Login == login && t.Parol == password).FirstOrDefault();
                    if (User != null)
                    {
                        var Polzovatel = Helper.GetContext().Sotrudniki.Where(t => User.KodAuthorizacii == t.KodParolia).FirstOrDefault();
                        int KodRoli = Polzovatel.KodRoli;
                        switch (KodRoli)
                        {
                            case 1:
                                this.NavigationService.Navigate(new Uri("Pages/polzovatel.xaml", UriKind.Relative));
                                break;
                            case 2:
                                this.NavigationService.Navigate(new Uri("Pages/admin.xaml", UriKind.Relative));
                                break;
                        }
                    }
                    else
                    {
                        unsuccesful++;
                        MessageBox.Show("Пользователь с таким логином не найден", "Внимание", MessageBoxButton.OK);
                        txtlogin.Text = null;
                        BoxPassword.Password = null;
                        GetCaptcha();
                    }
                }
                else
                {
                    string captca = txtboxCaptcha.Text;
                    var User = Helper.GetContext().Authorizacia.Where(t => t.Login == login && t.Parol == password).FirstOrDefault();
                    if (User != null && captca == txtBlockCaptcha.Text)
                    {
                        var Polzovatel = Helper.GetContext().Sotrudniki.Where(t => User.KodAuthorizacii == t.KodParolia).FirstOrDefault();
                        int KodRoli = Polzovatel.KodRoli;
                        switch(KodRoli)
                        {
                            case 1:
                                this.NavigationService.Navigate(new Uri("Pages/polzovatel.xaml", UriKind.Relative));
                                break;
                            case 2:
                                this.NavigationService.Navigate(new Uri("Pages/admin.xaml", UriKind.Relative));
                                break;
                        }
                    }
                    else
                    {
                        if(captca != txtBlockCaptcha.Text)
                        {
                            MessageBox.Show("Капча введена неверно", "Внимание", MessageBoxButton.OK);
                        }
                        if(User == null)
                        {
                            MessageBox.Show("Пользователь с таким логином не найден", "Внимание", MessageBoxButton.OK);
                        }
                        txtlogin.Text = null;
                        BoxPassword.Password = null;
                        txtboxCaptcha.Text = null;
                        GetCaptcha();
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
            string captcha = Captcha.Captcha.GenerateCaptca();
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
            txtBlockCaptcha.Text = captcha;
        }
    }
}
