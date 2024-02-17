using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeCaballo
{
    internal class AlgoritmoGenetico
    {
        int contador = 1;
        int meteorito = 0, adecuacionPasada=0;
        bool CriterioStop = false;
        Poblacion poblacion = new Poblacion();
        public void Empezar(string PrimeraCasilla, Random r)
        {
            poblacion.PrimeraGeneracion(PrimeraCasilla, r);//Calcula el mejor organismo
            poblacion.Ordenar();
            poblacion.MejorOrganismo.ImprimirCromosoma(contador);
            for(int i=1;!CriterioStop;i++ )
            {
                contador++;
                for(int x=0; x<4000;x++)
                {
                    poblacion.Population[x] = poblacion.PopulationOrdenada[x];
                }
                //Muta y cruza
                Cruzar(poblacion,r);// La cruza es lo que hace que el programa no sea elitista, debida a que existe la probabilidad de que organismos malos crucen y sobrevivan casi en su totalidad.
                Mutar(poblacion, r);// Mutar ayuda mucho, y ya es random en su totalidad
                for (int g = 0; g < 4000; g++)//Calcula todas las adecuaciones 
                {
                    poblacion.Population[g].adecuacion = 0;
                    poblacion.Population[g].CalcularAdecuacion();
                }
                poblacion.CalcularMejorOrganismo();
                poblacion.MejorOrganismo.ImprimirCromosoma(contador);
                poblacion.Ordenar();
                if (poblacion.MejorOrganismo.adecuacion == 63)
                    CriterioStop = true;   
                
                /*if(poblacion.Count% 7500 == 0 && poblacion.MejorOrganismo.adecuacion != 63)
                {
                    Empezar(PrimeraCasilla,r);
                }*/
                if (meteorito<5000)
                {
                    meteorito++;
                    if(adecuacionPasada<poblacion.MejorOrganismo.adecuacion)
                    {
                        meteorito = 0;
                        adecuacionPasada = poblacion.MejorOrganismo.adecuacion;
                    }
                }
                else
                {
                    contador = 1;
                    meteorito = 0;
                    Empezar(PrimeraCasilla, r);
                }
            }
        }
        public void Cruzar(Poblacion poblacion, Random r)//brute forceeando, tenemos que checar como funciona
        {
            int Minima = poblacion.Population[1999].adecuacion, Maxima=poblacion.MejorOrganismo.adecuacion;
            int x=r.Next(Minima, Maxima + 1);
            for (int z=0; z<2000;z=z+2 )
            {
                int j = 0, k=r.Next(0,4000),l=r.Next(0,4000);
                for (; j < x; j++)//individuo 1
                {
                    poblacion.Population[z+2000].cromosoma[j] = poblacion.Population[k].cromosoma[j];
                }
                for (; j < 126; j++)
                {
                    poblacion.Population[z+2000].cromosoma[j] = poblacion.Population[l].cromosoma[j];
                }
                j = 0;
                for (; j < x; j++)//individuo 2
                {
                    poblacion.Population[z + 2001].cromosoma[j] = poblacion.Population[l].cromosoma[j];
                }
                for (; j < 126; j++)
                {
                    poblacion.Population[z + 2001].cromosoma[j] = poblacion.Population[k].cromosoma[j];
                }
            }
        }
        public void Mutar(Poblacion poblacion, Random r)// Esta illegal, pero nos dejaste
        {
            int a = 0;
            for (int i = 0; i < 4000; i++)
            {
                a = poblacion.Population[i].adecuacion;
                poblacion.Population[i].cromosoma[a * 2] = r.Next(1, 9);
                poblacion.Population[i].cromosoma[a * 2 + 1] = r.Next(1, 9);
            }
        }

    }
}
