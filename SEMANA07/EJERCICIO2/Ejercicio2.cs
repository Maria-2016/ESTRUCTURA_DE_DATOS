using System;
using System.Collections.Generic;

public class Ejercicio2
{
    private Stack<int> origen = new Stack<int>();
    private Stack<int> auxiliar = new Stack<int>();
    private Stack<int> destino = new Stack<int>();
    private int numDiscos;

    public Ejercicio2(int numDiscos)
    {
        this.numDiscos = numDiscos;

        // Cargar los discos en la torre de origen (de mayor a menor)
        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Push(i);
        }

        Console.WriteLine("Estado inicial:");
        Console.WriteLine("Estado de las torres:");
        MostrarTorres();
        Console.WriteLine("-------------------------------------------------------");
    }

    public void Resolver()
    {
        MoverDiscos(numDiscos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
        Console.WriteLine("¡Todos los discos se han movido exitosamente!");
    }

    private void MoverDiscos(int n, Stack<int> desde, Stack<int> hacia, Stack<int> aux, string nombreDesde, string nombreHacia, string nombreAux)
    {
        if (n == 1)
        {
            int disco = desde.Pop();
            hacia.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreDesde} a {nombreHacia}");
            Console.WriteLine("Estado de las torres:");
            MostrarTorres();
            Console.WriteLine("-------------------------------------------------------");
            return;
        }

        MoverDiscos(n - 1, desde, aux, hacia, nombreDesde, nombreAux, nombreHacia);

        int discoFinal = desde.Pop();
        hacia.Push(discoFinal);
        Console.WriteLine($"Mover disco {discoFinal} de {nombreDesde} a {nombreHacia}");
        Console.WriteLine("Estado de las torres:");
        MostrarTorres();
        Console.WriteLine("-------------------------------------------------------");

        MoverDiscos(n - 1, aux, hacia, desde, nombreAux, nombreHacia, nombreDesde);
    }

    private void MostrarTorres()
    {
        Console.WriteLine($"Origen: {MostrarPila(origen)}");
        Console.WriteLine($"Auxiliar: {MostrarPila(auxiliar)}");
        Console.WriteLine($"Destino: {MostrarPila(destino)}");
    }

    private string MostrarPila(Stack<int> pila)
    {
        if (pila.Count == 0)
            return "";

        int[] discos = pila.ToArray();
        Array.Reverse(discos); // Mostrar del fondo al tope
        return string.Join("", discos);
    }
}
