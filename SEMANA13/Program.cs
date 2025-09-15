using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Catálogo de revistas en español
        static List<string> catalogo = new List<string>()
        {
            "Muy Interesante",
            "National Geographic en Español",
            "Revista Semana",
            "Revista Vistazo",
            "Revista Diners",
            "Selecciones Reader's Digest",
            "Revista Soho",
            "Revista Ñ",
            "Revista Eme",
            "Revista América Economía"
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Catálogo de Revistas ===");
                Console.WriteLine("1. Buscar revista");
                Console.WriteLine("2. Mostrar catálogo");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título a buscar: ");
                        string titulo = Console.ReadLine();
                        bool encontrado = BuscarIterativo(catalogo, titulo);
                        Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
                        break;

                    case 2:
                        Console.WriteLine("\nCatálogo de Revistas:");
                        foreach (var revista in catalogo)
                        {
                            Console.WriteLine("- " + revista);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 3);
        }

        // Búsqueda iterativa en el catálogo
        static bool BuscarIterativo(List<string> lista, string titulo)
        {
            foreach (var revista in lista)
            {
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
