

using System;
using System.Collections.Generic;

namespace NavegadorWeb
{
    class Navegador
    {
        private Stack<string> historial = new Stack<string>();

        public void VisitarPagina(string url)
        {
            historial.Push(url);
            Console.WriteLine($"\nVisitando: {url}");
        }

        public void Retroceder()
        {
            if (historial.Count > 1)
            {
                historial.Pop();
                Console.WriteLine($"\nRetrocediendo a: {historial.Peek()}");
            }
            else
            {
                Console.WriteLine("\nNo hay más páginas para retroceder.");
            }
        }

        public void MostrarHistorial()
        {
            Console.WriteLine("\nHistorial actual (de la más reciente a la más antigua):");
            foreach (string pagina in historial)
            {
                Console.WriteLine(" - " + pagina);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Navegador nav = new Navegador();
            int opcion;
            string url;

            do
            {
                Console.WriteLine("\n===== MENÚ DE NAVEGACIÓN =====");
                Console.WriteLine("1. Visitar nueva página");
                Console.WriteLine("2. Retroceder");
                Console.WriteLine("3. Mostrar historial");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la URL de la página: ");
                        url = Console.ReadLine();
                        nav.VisitarPagina(url);
                        break;
                    case 2:
                        nav.Retroceder();
                        break;
                    case 3:
                        nav.MostrarHistorial();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del navegador...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 4);
        }
    }
}
