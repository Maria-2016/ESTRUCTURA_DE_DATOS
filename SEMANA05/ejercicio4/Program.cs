
using System;
using System.Collections.Generic;

namespace NumerosLoteria
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una lista para almacenar los números ganadores
            List<int> numerosGanadores = new List<int>();

            // Pedimos al usuario que ingrese 6 números ganadores
            for (int i = 0; i < 6; i++)
            {
                Console.Write("Introduce un número ganador: ");
                string entrada = Console.ReadLine();       // Leer desde consola
                int numero = int.Parse(entrada);           // Convertir la entrada a número entero
                numerosGanadores.Add(numero);              // Agregar a la lista
            }

            // Ordenamos la lista de menor a mayor
            numerosGanadores.Sort();

            // Mostramos los números ganadores ordenados
            Console.WriteLine("Los números ganadores son: [" + string.Join(", ", numerosGanadores) + "]");
        }
    }
}
