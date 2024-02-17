using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeCaballo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Random r =new Random();
            string PrimeraCasilla="";
            Console.WriteLine("Introduce la casilla de inicio: Una letra de la A-H seguida de un número (sin espacio) del 1-8.");
            Console.WriteLine("ej. A1");
            PrimeraCasilla = Console.ReadLine();

            AlgoritmoGenetico AG=new AlgoritmoGenetico();
            AG.Empezar(PrimeraCasilla, r);
            Console.WriteLine("La secuencia ha sido encontrada, es la última entrada del archivo de texto.");
            Console.ReadKey();
        }
    }
}
