using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using AddPassword.models;
using Hash;
namespace AddPassword
{
    internal class AddUser
    {
        static void Main(string[] args)     
        {
            while (true)
            {
                Console.WriteLine("1.Добавить пользователя");
                Console.WriteLine("2.Выход");
                int Menu = Convert.ToInt32(Console.ReadLine());
                if (Menu == 1)
                {
                    try
                    {                    
                        Console.Clear();
                        var db = Helper.GetContext();
                        var Authorization = new Authorizacia();
                        var Brigadi = db.Brigadi;
                        var Rol = db.Roli;
                        var Polzovatel = new Sotrudniki();
                        Console.WriteLine("Введите  имя пользователя:    ");
                        string Imia = Console.ReadLine().Trim();
                        Console.WriteLine("Введите фамилию пользователя:   ");
                        string Familia = Console.ReadLine().Trim();
                        Console.WriteLine("Введите отчество:   ");
                        string Otchestvo = Console.ReadLine().Trim();
                        Console.WriteLine("Введите номер телефона:   ");
                        string NomerTel = Console.ReadLine().Trim();
                        bool TelFlag = Regex.IsMatch(NomerTel, @"8\([0-9][0-9][0-9]\)-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]");
                        Console.WriteLine("Введите почту:   ");
                        string Pochta = Console.ReadLine().Trim();
                        bool flagPochta = Regex.IsMatch(Pochta, @"\@");
                        Console.WriteLine("Введите логин:   ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Введите пароль:   ");
                        string password = Console.ReadLine().Trim();
                        string HashPasswd = Hash.Hash.HashPassword(password);
                        Console.WriteLine("Выберите роль:   ");
                        foreach (var item in Rol)
                        {
                            Console.WriteLine("{0}{1}", item.KodRoli, item.NaimenovanieRoli);
                        }
                        int KodRoli = -1;
                        bool flagRol = Int32.TryParse(Console.ReadLine(), out KodRoli);
                        Console.WriteLine("Выберите бригаду:   ");
                        foreach (var item in Brigadi)
                        {
                            Console.WriteLine("{0}  {1}", item.KodBrigadi, item.Naimenovanie);
                        }
                        int KodBrigadi = -1;
                        bool flagBrigadi = Int32.TryParse(Console.ReadLine(), out KodBrigadi);
                        if (KodRoli > 0 && KodRoli <= Rol.Count() && flagRol == true && flagBrigadi == true && KodBrigadi > 0 &&  KodBrigadi <= Brigadi.Count() && TelFlag == true && flagPochta == true)
                        {
                            Polzovatel.Imia = Imia;
                            Polzovatel.Familia = Familia;
                            Polzovatel.Otchestvo = Otchestvo;
                            Polzovatel.Pochta = Pochta;
                            Polzovatel.NomerTelefona = NomerTel;
                            Authorization.Login = login;
                            Authorization.Parol = HashPasswd;
                            Console.WriteLine(HashPasswd);
                            db.Authorizacia.Add(Authorization);
                            db.SaveChanges();
                            int KodParolia = Authorization.KodAuthorizacii;
                            Polzovatel.KodParolia = KodParolia;
                            Polzovatel.KodRoli = KodRoli;
                            Polzovatel.Brigada = KodBrigadi;
                            db.Sotrudniki.Add(Polzovatel);
                            db.SaveChanges();
                            Console.WriteLine("Пользователь добавлен:   ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            if (KodRoli < 0 || KodRoli > Rol.Count() || flagRol == false)
                            {
                                Console.WriteLine("Такой роли не существует");
                            }
                            if(flagBrigadi == false || KodBrigadi < 0 || KodBrigadi > Brigadi.Count())
                            {
                                Console.WriteLine("Такой бригады не существует");
                            }
                            if(TelFlag == false)
                            {
                                Console.WriteLine("Номер телефона введён не верно");
                            }
                            if(flagPochta == false)
                            {
                                Console.WriteLine("Почта введена неверно");
                            }
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.GetBaseException().Message);
                        Console.ReadKey();
                    }
                }
                else
                {
                    if(Menu == 2)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого пункта меню не существует");
                    }
                }
            }
        }
    }
}
