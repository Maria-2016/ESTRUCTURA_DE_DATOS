

using System;
using System.Collections.Generic;

public class Asignaturas
{
    public static void Main()
    {
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        Console.WriteLine("Las asignaturas del curso son:");
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine("- " + asignatura);
        }
    }
}

