using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    public class Captcha
    {
        public static string GenerateCaptca()
        {
            char[] Symbols = { 'A', 'B', 'C', 'E', 'Y', '1', '2', '5', '7' };
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Capacity = 15;
            Random random = new Random();
            int Dlina = random.Next(5, 15);
            int Nomer;
            while (Dlina > 0)
            {
                Nomer = random.Next(1, Symbols.Length);
                stringBuilder.Append(Symbols[Nomer]);
                Dlina--;
            }
            return (stringBuilder.ToString());
        }
    }
}
