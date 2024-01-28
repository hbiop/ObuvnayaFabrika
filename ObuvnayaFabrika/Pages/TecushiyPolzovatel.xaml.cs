using ObuvnayaFabrika.models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObuvnayaFabrika.Pages
{
    /// <summary>
    /// Логика взаимодействия для TecushiyPolzovatel.xaml
    /// </summary>
    public partial class TecushiyPolzovatel : Page
    {
        models.Sotrudniki Polzovatel;
        List<Roli> roli;
        List<Brigadi> brigadi;
        List<Authorizacia> authorizacia;
        public TecushiyPolzovatel(int kodPolzovatelia)
        {
            InitializeComponent();
            Init(kodPolzovatelia);
        }
        public void Init(int kodPolzovatelia)
        {
            Polzovatel = Helper.GetContext().Sotrudniki.Where(t => t.KodSotrudnika == kodPolzovatelia).FirstOrDefault();
            roli = Helper.GetContext().Roli.ToList();
            brigadi = Helper.GetContext().Brigadi.ToList();
            authorizacia = Helper.GetContext().Authorizacia.ToList();
            string naimenovanieRoli = roli.Where(t => t.KodRoli == Polzovatel.KodRoli).FirstOrDefault().NaimenovanieRoli;
            string naimenovanieBrigady = brigadi.Where(t => t.KodBrigadi == Polzovatel.Brigada).FirstOrDefault().Naimenovanie;
            cmbRol.DisplayMemberPath = "NaimenovanieRoli";
            cmbRol.ItemsSource = roli;
            tbLogin.Text = authorizacia.Where(t => t.KodAuthorizacii == Polzovatel.KodParolia).FirstOrDefault().Login;
            //tbparol.Text = authorizacia.Where(t => t.KodAuthorizacii == Polzovatel.KodParolia).FirstOrDefault().Parol;
            cmbBrigada.ItemsSource = brigadi;
            cmbBrigada.DisplayMemberPath = "Naimenovanie";
            tbFamilia.Text = Polzovatel.Familia;
            tbImia.Text = Polzovatel.Imia;
            tbOtchestvo.Text = Polzovatel.Otchestvo;
            tbNomerTelefona.Text = Polzovatel.NomerTelefona;
            tbPochta.Text = Polzovatel.Pochta;
            btSave.Content = "Сохранить";
            btSave.Click += saveUser;
            cmbRol.Text = naimenovanieRoli;
            cmbBrigada.Text = naimenovanieBrigady;
        }
        public TecushiyPolzovatel()
        {
            InitializeComponent();
            roli = Helper.GetContext().Roli.ToList();
            brigadi = Helper.GetContext().Brigadi.ToList();
            cmbRol.ItemsSource = roli;
            cmbRol.DisplayMemberPath = "NaimenovanieRoli";
            
            cmbBrigada.ItemsSource = brigadi;
            cmbBrigada.DisplayMemberPath = "Naimenovanie";
            cmbRol.SelectedIndex = 0;
            cmbBrigada.SelectedIndex = 0;
            btSave.Content = "Добавить";
            btSave.Click += addUser;
        }

        private void saveUser(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var db = Helper.GetContext();
            Polzovatel.Brigada = brigadi.Where(t => t.Naimenovanie == cmbBrigada.Text).FirstOrDefault().KodBrigadi;
            Polzovatel.KodRoli = roli.Where(t => t.NaimenovanieRoli == cmbRol.Text).FirstOrDefault().KodRoli;

            Polzovatel.Imia = tbImia.Text;
            Polzovatel.Familia = tbFamilia.Text;
            Polzovatel.Otchestvo = tbOtchestvo.Text;
            Polzovatel.NomerTelefona = tbNomerTelefona.Text;
            Polzovatel.Pochta = tbPochta.Text;
            Authorizacia authorizacia = Helper.GetContext().Authorizacia.Where(t => t.KodAuthorizacii == Polzovatel.KodParolia).FirstOrDefault();
            authorizacia.Login = tbLogin.Text;
            if(tbparol.Text != "")
            {
                authorizacia.Parol = Hash.Hash.HashPassword(tbparol.Text);
            }

            var ContextAuth = new ValidationContext(authorizacia);
            var ContextPolzovatel = new ValidationContext(Polzovatel);
            var ResultsAuth = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var ResultPolzovatel = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(authorizacia, ContextAuth, ResultsAuth, true))
            {
                Validator.TryValidateObject(Polzovatel, ContextPolzovatel, ResultPolzovatel, true);
                foreach (var error in ResultsAuth)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);

                }
                foreach (var error in ResultPolzovatel)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                MessageBox.Show(Convert.ToString(stringBuilder));
            }
            else
            {
                db.Entry(authorizacia).State = EntityState.Modified;
                db.SaveChanges();
                Polzovatel.KodParolia = authorizacia.KodAuthorizacii;
                ContextAuth = new ValidationContext(authorizacia);
                ContextPolzovatel = new ValidationContext(Polzovatel);
                ResultsAuth = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                ResultPolzovatel = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                if (!Validator.TryValidateObject(Polzovatel, ContextPolzovatel, ResultPolzovatel, true))
                {
                    foreach (var error in ResultPolzovatel)
                    {
                        stringBuilder.AppendLine(error.ErrorMessage);

                    }
                    MessageBox.Show(Convert.ToString(stringBuilder));
                }
                else
                {
                    db.Entry(Polzovatel).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Пользователь изменен");
                }
            }
        }
        private void addUser(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var db = Helper.GetContext();
            Polzovatel = new Sotrudniki();
            var authorizacia = new Authorizacia();
            authorizacia.Login = tbLogin.Text;
            
            authorizacia.Parol = Hash.Hash.HashPassword(tbparol.Text);
            Polzovatel.Brigada = brigadi.Where(t => t.Naimenovanie == cmbBrigada.Text).FirstOrDefault().KodBrigadi;
            Polzovatel.KodRoli = roli.Where(t => t.NaimenovanieRoli == cmbRol.Text).FirstOrDefault().KodRoli;
            Polzovatel.KodParolia = authorizacia.KodAuthorizacii;
            Polzovatel.Imia = tbImia.Text;
            Polzovatel.Familia = tbFamilia.Text;
            Polzovatel.Otchestvo = tbOtchestvo.Text;
            Polzovatel.NomerTelefona = tbNomerTelefona.Text;
            Polzovatel.Pochta = tbPochta.Text;
            var ContextAuth = new ValidationContext(authorizacia);
            var ContextPolzovatel = new ValidationContext(Polzovatel);
            var ResultsAuth = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var ResultPolzovatel = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(authorizacia, ContextAuth, ResultsAuth, true))
            {
                Validator.TryValidateObject(Polzovatel, ContextPolzovatel, ResultPolzovatel, true);
                foreach (var error in ResultsAuth)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);

                }
                foreach(var error in ResultPolzovatel)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                MessageBox.Show(Convert.ToString(stringBuilder));
            }
            else
            {
                db.Authorizacia.Add(authorizacia);
                db.SaveChanges();
                
                Polzovatel.KodParolia = authorizacia.KodAuthorizacii;
                if (!Validator.TryValidateObject(Polzovatel, ContextPolzovatel, ResultPolzovatel, true))
                {
                    db.Authorizacia.Remove(authorizacia);
                    db.SaveChanges();
                    foreach (var error in ResultPolzovatel)
                    {
                        stringBuilder.AppendLine(error.ErrorMessage);
                    }
                    MessageBox.Show(Convert.ToString(stringBuilder));
                }
                else
                {
                    db.Sotrudniki.Add(Polzovatel);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь создан");
                }
            }
            
        }
    }
}
