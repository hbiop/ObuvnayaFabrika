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
using System.Windows.Threading;
using System.Threading;
using System.Timers;
namespace ObuvnayaFabrika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Autho()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
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
                            if (captca != txtBlockCaptcha.Text)
                            {
                                MessageBox.Show("Капча введена неверно", "Внимание", MessageBoxButton.OK);
                            }
                            if (User == null)
                            {
                                MessageBox.Show("Пользователь с таким логином не найден", "Внимание", MessageBoxButton.OK);
                            }
                            txtlogin.Text = null;
                            BoxPassword.Password = null;
                            txtboxCaptcha.Text = null;
                            unsuccesful++;
                            GetCaptcha();
                        if (unsuccesful >= 3)
                        {
                            startTimer();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private void GetCaptcha()
        {
            txtboxCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;
            string captcha = Captcha.Captcha.GenerateCaptca();
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
            txtBlockCaptcha.Text = captcha;
        }
        static int remainingTime;
       
        private void startTimer()
        {
            remainingTime = 11;
            txtboxCaptcha.Visibility = Visibility.Hidden;
            txtlogin.Text = null;
            BoxPassword.Password = null;
            txtboxCaptcha.Text = null;
            txtBlockCaptcha.Visibility = Visibility.Hidden;
            txtlogin.Visibility = Visibility.Hidden;
            BoxPassword.Visibility = Visibility.Hidden;
            tbLogin.Visibility = Visibility.Hidden;
            tbPassword.Visibility = Visibility.Hidden;
            txtboxCaptcha.Visibility = Visibility.Hidden;
            txtBlockCaptcha.Visibility = Visibility.Hidden;
            btnEnterGuests.Visibility = Visibility.Hidden;
            btnEnter.Visibility = Visibility.Hidden;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }
        
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            txtTimer.Text = $"Будет разблокировано через {remainingTime} секунд";
            txtTimer.Foreground = Brushes.Red;
            txtTimer.Visibility = Visibility.Visible;
            if (remainingTime == 0)
            {
                txtTimer.Visibility = Visibility.Hidden;
                txtboxCaptcha.Visibility = Visibility.Visible;
                txtBlockCaptcha.Visibility = Visibility.Visible;
                txtlogin.Visibility = Visibility.Visible;
                BoxPassword.Visibility = Visibility.Visible;
                tbLogin.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Visible;
                txtboxCaptcha.Visibility = Visibility.Visible;
                txtBlockCaptcha.Visibility = Visibility.Visible;
                btnEnterGuests.Visibility = Visibility.Visible;
                btnEnter.Visibility = Visibility.Visible;
                dispatcherTimer.Stop();
            }
        }
    }
}
