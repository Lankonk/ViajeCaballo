using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ViajeCaballo
{
    internal class Organismo
    {
        
        public int letra, numero;
        public int[] cromosoma= new int[126];
        public int adecuacion=0;
        bool c1, c2, c3, c4;
        bool[,] tablero = new bool[8, 8];
        public void CalcularAdecuacion()
            {
            
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    tablero[x, y] = false;
            tablero[letra - 1, numero - 1] = true;
            for (int i = 0; ; i = i + 2)
            {
                if (adecuacion == 0)
                {
                    c1 = ((cromosoma[i] == letra + 2) && ((cromosoma[i + 1] == numero + 1) || (cromosoma[i + 1] == numero - 1)));
                    c2 = ((cromosoma[i] == letra - 2) && ((cromosoma[i + 1] == numero + 1) || (cromosoma[i + 1] == numero - 1)));
                    c3 = ((cromosoma[i + 1] == numero + 2) && ((cromosoma[i] == letra + 1) || (cromosoma[i] == letra - 1)));
                    c4 = ((cromosoma[i + 1] == numero - 2) && ((cromosoma[i] == letra + 1) || (cromosoma[i] == letra - 1)));
                    if (c1 || c2 || c3 || c4)
                    {
                        adecuacion++;
                        tablero[cromosoma[i] - 1, cromosoma[i + 1]-1] = true;
                    }
                    else
                        break;
                }
                    else
                    {

                        c1 = ((cromosoma[i] == cromosoma[i - 2] + 2) && ((cromosoma[i + 1] == cromosoma[i - 1] + 1) || (cromosoma[i + 1] == cromosoma[i - 1] - 1)));
                        c2 = ((cromosoma[i] == cromosoma[i - 2] - 2) && ((cromosoma[i + 1] == cromosoma[i - 1] + 1) || (cromosoma[i + 1] == cromosoma[i - 1] - 1)));
                        c3 = ((cromosoma[i + 1] == cromosoma[i - 1] + 2) && ((cromosoma[i] == cromosoma[i - 2] + 1) || (cromosoma[i] == cromosoma[i - 2] - 1)));
                        c4 = ((cromosoma[i + 1] == cromosoma[i - 1] - 2) && ((cromosoma[i] == cromosoma[i - 2] + 1) || (cromosoma[i] == cromosoma[i - 2] - 1)));
                    
                    if ((c1 || c2 || c3 || c4)&& !tablero[cromosoma[i] - 1, cromosoma[i + 1] - 1] )
                    {                     
                            adecuacion++;
                            tablero[cromosoma[i] - 1, cromosoma[i + 1] - 1] = true;                                               
                    }
                    else
                        break;
                    }
                if (adecuacion == 63)
                    break;
            }
            }
        public void CromosomaAleatorio(Random r)
        {
            for (int i = 0; i < 126; i++)
            {
                cromosoma[i] = r.Next(1,9);
            }
        }
        public void ImprimirCromosoma(int contador)//cambiar para que imprima bonito
        {
            Console.WriteLine("Mejor individuo de la generación "+ contador);
            switch (letra)
            {
                case 1:
                    Console.Write("A");
                    break;
                case 2:
                    Console.Write("B");
                    break;
                case 3:
                    Console.Write("C");
                    break;
                case 4:
                    Console.Write("D");
                    break;
                case 5:
                    Console.Write("E");
                    break;
                case 6:
                    Console.Write("F");
                    break;
                case 7:
                    Console.Write("G");
                    break;
                case 8:
                    Console.Write("H");
                    break;
            }
            Console.Write(numero+", ");
            for (int file = 0; file < 126; file = file + 2)
            {
                switch (cromosoma[file])
                {
                    case 1:
                        Console.Write("A");
                        break;
                    case 2:
                        Console.Write("B");
                        break;
                    case 3:
                        Console.Write("C");
                        break;
                    case 4:
                        Console.Write("D");
                        break;
                    case 5:
                        Console.Write("E");
                        break;
                    case 6:
                        Console.Write("F");
                        break;
                    case 7:
                        Console.Write("G");
                        break;
                    case 8:
                        Console.Write("H");
                        break;
                }
                if (file < 124)
                    Console.Write(cromosoma[file + 1] + ", ");
                else
                    Console.Write(cromosoma[file + 1] + ".");
            }
            Console.WriteLine();
            Console.WriteLine("Adecuación: " + adecuacion);

            StreamWriter writer = new StreamWriter("Secuencia.txt", true);
            writer.WriteLine("Mejor individuo de la generación "+ contador);
            switch (letra)
            {
                case 1:
                    writer.Write("A");
                    break;
                case 2:
                    writer.Write("B");
                    break;
                case 3:
                    writer.Write("C");
                    break;
                case 4:
                    writer.Write("D");
                    break;
                case 5:
                    writer.Write("E");
                    break;
                case 6:
                    writer.Write("F");
                    break;
                case 7:
                    writer.Write("G");
                    break;
                case 8:
                    writer.Write("H");
                    break;
            }
            writer.Write(numero + ", ");
            for (int file = 0; file < 126; file = file + 2)
            {
                switch (cromosoma[file])
                {
                    case 1:
                        writer.Write("A");
                        break;
                    case 2:
                        writer.Write("B");
                        break;
                    case 3:
                        writer.Write("C");
                        break;
                    case 4:
                        writer.Write("D");
                        break;
                    case 5:
                        writer.Write("E");
                        break;
                    case 6:
                        writer.Write("F");
                        break;
                    case 7:
                        writer.Write("G");
                        break;
                    case 8:
                        writer.Write("H");
                        break;
                }
                if (file < 124)
                    writer.Write(cromosoma[file + 1] + ", ");
                else
                    writer.Write(cromosoma[file + 1]+".");
            }
            writer.WriteLine("");
            writer.WriteLine("Adecuación: " + adecuacion);
            writer.Close();
            
        }

    }
}
