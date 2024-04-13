using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObuvnayaFabrika
{
    /// <summary>
    /// Класс для работы с почтой
    /// </summary>
    public class SendMessage
    {
        public static string password = "RyD6VUanAeEbQnBFvccT";
        /// <summary>
        /// Метод для отправки кодов двухфакторной аутентификации на почту
        /// </summary>
        public static int SendCode(string mail)
        {
            Random random = new Random();
            int KodAuthentificacii = random.Next(1000, 9999);
            MailAddress from = new MailAddress("hbiopme2298@mail.ru");
            MailAddress to = new MailAddress(mail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код двухфакторной аутентификации";
            m.Body = "<h2>Код двухфакторной аутентификации - " + KodAuthentificacii + "</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("hbiopme2298@mail.ru", password);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(m);
            return KodAuthentificacii;
        }
    }
}
