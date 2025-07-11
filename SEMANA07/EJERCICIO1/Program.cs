/* Verificación de paréntesis balanceados en una expresión matemática
Implemente un programa que determine si los paréntesis, llaves y corchetes 
en una expresión matemática están correctamente balanceados.
Ejemplo:
Entrada: {7 + (8 * 5) - [(9 - 7) + (4 + 1)]}
Salida esperada: Fórmula balanceada.
*/

using System;

class Program
{
    static void Main()
    {
        // Solicitar al usuario que ingrese una expresión matemática
        Console.WriteLine("Ingrese una expresión matemática:");
        string expresion = Console.ReadLine();

        // Llamar al método para verificar si está balanceada
        if (Ejercicio1.EstaBalanceado(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}
