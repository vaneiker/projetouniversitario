using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var data  = Singleton.Instance.oContactManger.Getcontact();
            var data2 = Singleton.Instance.oContactManger.Getcontact2();
            var data3 = Singleton.Instance.oContactManger.Getcontact3();


            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            foreach (var item in data3)
            {
                Console.WriteLine(item);
            }

            foreach (var item in data3)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
