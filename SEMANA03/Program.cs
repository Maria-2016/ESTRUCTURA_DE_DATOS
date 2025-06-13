// Importamos el espacio de nombres necesario para trabajar con entradas y salidas
using System;

// Definimos un namespace para organizar las clases
namespace RegistroEstudiantes
{
    // Definimos la clase Estudiante con propiedades y método
    class Estudiante
    {
        // ID del estudiante
        public int Id { get; set; }

        // Nombres del estudiante
        public string Nombres { get; set; }

        // Apellidos del estudiante
        public string Apellidos { get; set; }

        // Dirección del estudiante
        public string Direccion { get; set; }

        // Array de 3 teléfonos
        public string[] Telefonos { get; set; } = new string[3];

        // Método que imprime la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("----- DATOS DEL ESTUDIANTE -----");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    // Clase principal que ejecuta el programa
    class Program
    {
        // Método principal
        static void Main(string[] args)
        {
            // Creamos un objeto estudiante y asignamos sus valores directamente
            Estudiante estudiante = new Estudiante
            {
                Id = 1001,
                Nombres = "María Rocío",
                Apellidos = "Vera Utrera",
                Direccion = "Comunidad Valle del Sade, Quinindé - Esmeraldas",
                Telefonos = new string[] { "0987654321", "022345678", "0991122334" }
            };

            // Mostramos la información del estudiante
            estudiante.MostrarInformacion();
        }
    }
}
