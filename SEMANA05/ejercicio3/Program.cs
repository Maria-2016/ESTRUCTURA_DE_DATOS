
using System;
using System.Collections.Generic;

namespace CursoAsignaturasConNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista de asignaturas del curso
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Lista para almacenar las notas que el usuario ingresará
            List<string> notas = new List<string>();

            // Bucle para solicitar una nota por cada asignatura
            foreach (string asignatura in asignaturas)
            {
                Console.Write($"¿Qué nota has sacado en {asignatura}? ");
                string nota = Console.ReadLine(); // Leer la nota desde el teclado
                notas.Add(nota); // Guardar la nota en la lista
            }

            Console.WriteLine(); // Línea en blanco para separar visualmente la salida

            // Mostrar los resultados
            for (int i = 0; i < asignaturas.Count; i++)
            {
                Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
            }
        }
    }
}
