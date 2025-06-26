using System;
using System.Collections.Generic;  // Necesario para trabajar con List<string>

namespace CursoAsignaturas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una lista con las asignaturas del curso
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Recorremos la lista e imprimimos un mensaje para cada asignatura
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine("Yo estudio " + asignatura);
            }
        }
    }
}

