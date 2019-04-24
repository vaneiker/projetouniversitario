using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static DateTime CalculoFechas(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        public static string Encode(string encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }
        static void Main(string[] args)
        {
            string HostName = Environment.MachineName; 
            string fechaInicio = Convert.ToString(DateTime.Now.ToShortDateString());
            
            try
            { 
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(@"F:\ruta\Test.eik");
                string texto = "Nombre Maquina :{0} \n Fecha Inicio :{1} \n Fecha Fin :#{2}";
                texto = string.Format(texto, HostName, fechaInicio, CalculoFechas(Convert.ToDateTime(fechaInicio)));
                
                sw.WriteLine(Encode(texto));

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            string text = System.IO.File.ReadAllText(@"F:\ruta\Test.eik");

           

            System.Console.WriteLine("Lo que dice el archivo = {0}", text);
            System.Console.WriteLine("Texto des = {0}", Decode(text));
            var a = Decode(text);
            var sp = a.Split('#');
            if (sp.Count() > 1)
            {
                var c = Convert.ToDateTime(sp[1]);

                if (DateTime.Now.Date>c.Date)
                {
                    Console.Write("Fecha expirada");
                } else
                {
                    Console.Write("Fecha vigente");
                }
                
            }

            Console.WriteLine("Presione cualquier tecla para salir.");
            System.Console.ReadKey();
        }
    }
}