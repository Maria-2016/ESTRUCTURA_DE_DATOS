/* Resolución del problema de las Torres de Hanoi
Desarrolle un algoritmo que resuelva el problema
 de las Torres de Hanoi utilizando pilas. 
El programa debe mostrar paso a paso cómo
 se mueven los discos entre las torres.
 */
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese la cantidad de discos:");
        if (!int.TryParse(Console.ReadLine(), out int numDiscos) || numDiscos <= 0)
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        Ejercicio2 torres = new Ejercicio2(numDiscos);
        torres.Resolver();
    }
}
