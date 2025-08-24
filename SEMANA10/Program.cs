using System;
using System.Collections.Generic;

public class CampanaVacunacion
{
    public static void Main(string[] args)
    {
        // 1. Generar datos ficticios
        Console.WriteLine("=== Campaña de Vacunación COVID-19 ===\n");

        var ciudadanosTotales = GenerarCiudadanos(500, 1);
        var vacunadosPfizer = GenerarCiudadanos(75, 1);
        var vacunadosAstraZeneca = GenerarCiudadanos(75, 200); // Se genera con otro rango para diferenciarlos

        // Simular que algunos ciudadanos han recibido ambas dosis
        var ciudadanosConAmbasDosis = new HashSet<string>();
        var random = new Random();

        // Aquí controlamos que exactamente 13 reciban ambas dosis
        while (ciudadanosConAmbasDosis.Count < 13)
        {
            var ciudadano = vacunadosPfizer[random.Next(vacunadosPfizer.Count)];
            ciudadanosConAmbasDosis.Add(ciudadano);
            vacunadosAstraZeneca.Add(ciudadano);
        }

        // 2. Aplicar operaciones de teoría de conjuntos
        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        var todosVacunados = new HashSet<string>(vacunadosPfizer);
        todosVacunados.UnionWith(vacunadosAstraZeneca);

        var noVacunados = new HashSet<string>(ciudadanosTotales);
        noVacunados.ExceptWith(todosVacunados);

        // 3. Mostrar resultados
        Console.WriteLine($"Total ciudadanos: {ciudadanosTotales.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {vacunadosPfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Sólo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Sólo AstraZeneca: {soloAstraZeneca.Count}");
    }

    // Método para generar ciudadanos ficticios
    public static List<string> GenerarCiudadanos(int cantidad, int inicio)
    {
        var lista = new List<string>();
        for (int i = inicio; i < inicio + cantidad; i++)
        {
            lista.Add($"Ciudadano {i}");
        }
        return lista;
    }
}

