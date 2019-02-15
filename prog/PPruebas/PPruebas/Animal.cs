using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPruebas
{
    interface IAnimalBase
    {
        void HacerRuido();
    }



    public abstract class Animal : IAnimalBase
    {
        private string _nombre;
        public string Nombre { get { return this._nombre; } set { this._nombre = value; } }

        public abstract void HacerRuido();

    }

    public class Vaca : Animal
    {
        public override void HacerRuido()
        {
            Console.Write("La Vaca hace Muuuuuu\n");
        }
    }

    public class Perro : Animal
    {
        public override void HacerRuido()
        {
            Console.Write("El Perro hace Jau jau jau\n");

        }

    }

    public class Gato : Animal
    {
        public override void HacerRuido()
        {
            Console.Write("El gato hace Miau Miau Miau\n");

        }
    }

    class Toro : Animal
    {
        public override void HacerRuido()
        {
            Console.Write("Este Toro hace Muuuuuuu");
        }
    }
}
