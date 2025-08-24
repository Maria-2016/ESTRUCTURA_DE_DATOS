using System;
using System.Collections.Generic;

class ProgramaVacunacion
{
    static void Main()
    {
        // Crear conjunto de ciudadanos
        List<string> ciudadanos = new List<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        Random rand = new Random();

        // Generar conjunto ficticio de vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        while (vacunadosPfizer.Count < 75)
        {
            int index = rand.Next(ciudadanos.Count);
            vacunadosPfizer.Add(ciudadanos[index]);
        }

        // Generar conjunto ficticio de vacunados con AstraZeneca
        HashSet<string> vacunadosAstra = new HashSet<string>();
        while (vacunadosAstra.Count < 75)
        {
            int index = rand.Next(ciudadanos.Count);
            vacunadosAstra.Add(ciudadanos[index]);
        }

        // Operaciones de teoría de conjuntos
        // Ambas dosis (intersección)
        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstra);

        // Solo Pfizer (diferencia)
        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstra);

        // Solo AstraZeneca (diferencia)
        var soloAstra = new HashSet<string>(vacunadosAstra);
        soloAstra.ExceptWith(vacunadosPfizer);

        // No vacunados (diferencia con la unión)
        var todosVacunados = new HashSet<string>(vacunadosPfizer);
        todosVacunados.UnionWith(vacunadosAstra);

        var noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(todosVacunados);

        // Mostrar resultados
        Console.WriteLine("=== Campaña de Vacunación COVID-19 ===");
        Console.WriteLine($"Total ciudadanos: {ciudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {vacunadosPfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {vacunadosAstra.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Sólo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Sólo AstraZeneca: {soloAstra.Count}");
    }
}
