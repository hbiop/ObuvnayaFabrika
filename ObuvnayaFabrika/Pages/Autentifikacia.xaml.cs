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
    /// Логика взаимодействия для Autentifikacia.xaml
    /// </summary>
    public partial class Autentifikacia : Page
    {
        Sotrudniki Polzovatel;
        Authorizacia auth;
        int kodAuth = -1;
        int kod;
        string Pochta;
        public Autentifikacia(Sotrudniki Polzovatel, int kodAuth)
        {
            InitializeComponent();
            this.Polzovatel = Polzovatel;
            this.kodAuth = kodAuth;
            this.Pochta = Polzovatel.Pochta;
            btn_podtverdit.Visibility = Visibility.Hidden;
            btn_podtverdit.Click += Podtvredit;
        }
        public Autentifikacia()
        {
            InitializeComponent();
            lb_message.Content = "введите почту";
            btn_podtverdit.Visibility = Visibility.Hidden;
            btn_podtverdit.Click += Podtvredit;
        }
        /// <summary>
        /// Обработчик нажатия кнопки для отправки кода двухфакторной аутентификации на почту
        /// </summary>
        private void SendCode(object sender, RoutedEventArgs e)
        {
            
            if (tb_kod.Text != null)
            {
                if (Pochta == null)
                {
                    Pochta = tb_kod.Text;
                }
                lb_message.Content = "введите код";
                kod = SendMessage.SendCode(Pochta);
                btn_podtverdit.Visibility = Visibility.Visible;
                tb_kod.Text = null;
            }
            else
            {
                MessageBox.Show("Введите почту");
            }
        }
        
        /// <summary>
        /// Обработчик нажатия кнопки для подтверждения ввода кода двухфакторной аутентификации
        /// </summary>
        private void SmenitParol(object sender, RoutedEventArgs e)
        {
            if (tb_kod.Text.Trim() != null)
            {
                var db = Helper.GetContext();
                Polzovatel = Helper.GetContext().Sotrudniki.FirstOrDefault(r => r.Pochta == Pochta);
                auth = Helper.GetContext().Authorizacia.FirstOrDefault(r => Polzovatel.KodParolia == r.KodAuthorizacii);
                auth.Parol = Hash.Hash.HashPassword(tb_kod.Text.Trim());
                db.Entry(auth).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Пароль был изменён");
                Autho main = new Autho();
                this.NavigationService.Navigate(main);
            }
            else
            {
                MessageBox.Show("Не введён пароль");
            }
        }
        private void Podtvredit(object sender, RoutedEventArgs e)
        {
            if (tb_kod.Text == kod.ToString())
            {
                if (kodAuth != -1)
                {
                    string Fio = Polzovatel.Imia + " " + Polzovatel.Familia + " " + Polzovatel.Otchestvo;
                    switch (kodAuth)
                    {
                        case 1:
                            polzovatel Polzovatel2 = new polzovatel(Fio);
                            this.NavigationService.Navigate(Polzovatel2);
                            break;
                        case 2:
                            admin Admin = new admin(Fio);
                            this.NavigationService.Navigate(Admin);
                            break;
                    }
                }
                else
                {
                    lb_message.Content = "Введите новый пароль";
                    tb_kod.Text = null;
                    btn_podtverdit.Click -= Podtvredit;
                    btn_podtverdit.Click += SmenitParol;
                }
            }
            else
            {
                MessageBox.Show("Код не верен\n На почту будет отправлен другой код");
                kod = SendMessage.SendCode(Polzovatel.Pochta);
            }
        }
    }
}
