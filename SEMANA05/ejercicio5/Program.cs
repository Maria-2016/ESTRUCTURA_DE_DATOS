
using System;
using System.Collections.Generic;

namespace NumerosInversos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista con los números del 1 al 10
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Números del 1 al 10 en orden inverso (usando índices):");

            // Recorremos la lista desde el final al principio usando índices
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(numeros[numeros.Count - i]);

                // Agregamos coma solo si no es el último número
                if (i < 10)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine(); // Salto de línea
        }
    }
}
