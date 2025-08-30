using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    // Diccionario: clave = palabra en español, valor = traducción al inglés
    static Dictionary<string, string> diccionario = new Dictionary<string, string>();

    static void Main()
    {
        // Cargar palabras iniciales al diccionario
        CargarBase();

        // Bucle principal del programa
        while (true)
        {
            // Menú de opciones
            Console.WriteLine("\n--------MENU------");
            Console.WriteLine("1. Traducir frase");
            Console.WriteLine("2. Agregar palabra");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            // Leer la opción ingresada por el usuario
            string opcion = Console.ReadLine();

            // Ejecutar acción según opción
            switch (opcion)
            {
                case "1":
                    TraducirFrase(); // Función que traduce frases
                    break;
                case "2":
                    AgregarPalabra(); // Función para agregar nuevas palabras
                    break;
                case "0":
                    Console.WriteLine("Saliendo del programa...");
                    return; // Termina la ejecución
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }

    // Función para inicializar el diccionario con palabras base
    static void CargarBase()
    {
        diccionario.Add("vida", "life");
        diccionario.Add("corta", "short");
        diccionario.Add("infeliz", "unhappy");
        diccionario.Add("dia", "day");  // sin tilde para evitar errores
        diccionario.Add("obra", "work");
    }

    // Función para traducir frases ingresadas por el usuario
    static void TraducirFrase()
    {
        Console.WriteLine("\nIngrese la frase a traducir:");
        string frase = Console.ReadLine();

        // Separar la frase en palabras y conservar espacios
        string[] palabras = Regex.Split(frase, @"(\s+)");

        Console.WriteLine("Frase traducida:");

        foreach (string palabra in palabras)
        {
            // Conservar espacios
            if (string.IsNullOrWhiteSpace(palabra))
            {
                Console.Write(palabra);
                continue;
            }

            // Limpiar signos de puntuación al final
            string palabraLimpia = palabra.TrimEnd(',', '.', ';', ':', '!', '?');

            // Verificar si la palabra existe en el diccionario
            if (diccionario.ContainsKey(palabraLimpia.ToLower()))
            {
                string traduccion = diccionario[palabraLimpia.ToLower()];

                // Mantener mayúscula inicial si corresponde
                if (Char.IsUpper(palabraLimpia[0]))
                    traduccion = Char.ToUpper(traduccion[0]) + traduccion.Substring(1);

                // Escribir palabra traducida + signo de puntuación si existía
                Console.Write(traduccion + palabra.Substring(palabraLimpia.Length));
            }
            else
            {
                // Imprimir palabra original si no está en el diccionario
                Console.Write(palabra);
            }
        }

        Console.WriteLine(); // Salto de línea al final
    }

    // Función para agregar nuevas palabras al diccionario
    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en español: ");
        string esp = Console.ReadLine();
        Console.Write("Ingrese la traducción al inglés: ");
        string eng = Console.ReadLine();

        // Evitar duplicados en el diccionario
        if (!diccionario.ContainsKey(esp.ToLower()))
        {
            diccionario.Add(esp.ToLower(), eng.ToLower());
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}
