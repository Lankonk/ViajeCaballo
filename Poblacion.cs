using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeCaballo
{
    internal class Poblacion
    {
        public Organismo MejorOrganismo;
        public Organismo [] Population=new Organismo [4000];//Si funciona baja a 2000
        public Organismo[] PopulationOrdenada = new Organismo[4000];//jola
        public void PrimeraGeneracion(string PrimeraCasilla, Random r)
        {
            string letra=PrimeraCasilla.TrimEnd('1','2','3','4','5','6','7','8'), numero=PrimeraCasilla.TrimStart('A','B','C','D','E','F','G','H','a','b','c','d','e','f','g','h');
            letra = letra.ToUpper();
            switch(letra)
            {
                case "A":
                    letra = "1";
                    break;
                case "B":
                    letra = "2";
                    break;
                case "C":
                    letra = "3";
                    break;
                case "D":
                    letra = "4";
                    break;
                case "E":
                    letra = "5";
                    break;
                case "F":
                    letra = "6";
                    break;
                case "G":
                    letra = "7";
                    break;
                case "H":
                    letra = "8";
                    break;
            }
            for (int i = 0; i < 4000; i++)
            {
                Organismo org = new Organismo();
                org.CromosomaAleatorio(r);
                org.letra = Int16.Parse(letra);
                org.numero = Int16.Parse(numero);
                org.CalcularAdecuacion();
                Population[i] = org;
            }
            CalcularMejorOrganismo();
        }
        public void ImprimirPoblacion(int contador)//Cambio a Ordenada
        {
            for (int i = 0; i < 2000; i++)   
             PopulationOrdenada[i].ImprimirCromosoma(contador);             
        }
        public void ImprimirMejores(int contador)//Cambio a Ordenada
        {
            for (int i = 0; i < 2000; i++)            
                if (PopulationOrdenada[i].adecuacion > 0)// Nada más se imprimen los mejores
                    PopulationOrdenada[i].ImprimirCromosoma(contador);
            
        }
        public void CalcularMejorOrganismo()
        {       
            MejorOrganismo = Population[0];
            for (int i=1;i<4000;i++)
                if(Population[i].adecuacion> MejorOrganismo.adecuacion)
                    MejorOrganismo= Population[i];
            
        }
        public void Ordenar()
        {           
            int contador = 0;
            for (int x = MejorOrganismo.adecuacion; x >-1;x--)
            for (int i = 0;i<4000;i++)//jola
            {
                    if (Population[i].adecuacion == x)
                    {
                        PopulationOrdenada[contador] = Population[i];
                        contador++;
                    }
            }
        }
    }

}
