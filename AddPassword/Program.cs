using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Hash;
using ObuvnayaFabrika;
using ObuvnayaFabrika.Model;
namespace AddPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = Helper.GetContext();
                var Authorization = new Authorizacia();
                Console.WriteLine("Введите код пользователя:    ")
                int KodSotrudnika = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите логин:   ");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль:   ")
                string password = Console.ReadLine();
                string HashPasswd = Hash.Hash.HashPassword(password);
                //Authorization.KodAuthorizacii = 1;
                Authorization.Login = login;
                Authorization.Parol = HashPasswd;
                Console.WriteLine(HashPasswd);
                Authorization.Sotrudnik = KodSotrudnika;
                db.Authorizacia.Add(Authorization);
                db.SaveChanges();
            }
            catch(DbEntityValidationException ex) 
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.Write("Object: " + validationError.Entry.Entity.ToString());
                    Console.Write("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.Write(err.ErrorMessage + "");
                        }
                }
                Console.ReadKey();
            }
        }
    }
}
