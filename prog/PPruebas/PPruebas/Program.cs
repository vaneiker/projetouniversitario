using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            string saludo = "Hola {0}, como estas";
            var mensaje = string.Format(saludo, "Pedro Jose Van eiker");
            var mensajep = $"Saludos{mensaje}";
            string[] estender = mensajep.Split(' ');
            Console.Read();
        }
    }
}
