using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    // Clase Jugador
    class Jugador
    {
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Posicion { get; set; }

        public Jugador(string nombre, int numero, string posicion)
        {
            Nombre = nombre;
            Numero = numero;
            Posicion = posicion;
        }

        // Override Equals y GetHashCode para HashSet
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Jugador j = (Jugador)obj;
            return Nombre.Equals(j.Nombre, StringComparison.OrdinalIgnoreCase) && Numero == j.Numero;
        }

        public override int GetHashCode()
        {
            return Nombre.ToLower().GetHashCode() ^ Numero.GetHashCode();
        }

        public override string ToString()
        {
            return $"#{Numero} - {Nombre} ({Posicion})";
        }
    }

    // Clase Equipo
    class Equipo
    {
        public string NombreEquipo { get; set; }
        public HashSet<Jugador> Jugadores { get; set; }

        public Equipo(string nombre)
        {
            NombreEquipo = nombre;
            Jugadores = new HashSet<Jugador>();
        }

        public bool AgregarJugador(Jugador jugador)
        {
            if (Jugadores.Add(jugador))
            {
                Console.WriteLine($"Jugador {jugador.Nombre} agregado correctamente al equipo {NombreEquipo}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Jugador {jugador.Nombre} ya existe en el equipo {NombreEquipo}.");
                return false;
            }
        }

        public void MostrarJugadores()
        {
            if (Jugadores.Count == 0)
            {
                Console.WriteLine($"El equipo {NombreEquipo} no tiene jugadores registrados.");
            }
            else
            {
                Console.WriteLine($"Jugadores del equipo {NombreEquipo}:");
                foreach (var jugador in Jugadores)
                {
                    Console.WriteLine(jugador.ToString());
                }
            }
        }
    }

    // Clase Torneo
    class Torneo
    {
        public Dictionary<string, Equipo> Equipos { get; set; }

        public Torneo()
        {
            Equipos = new Dictionary<string, Equipo>(StringComparer.OrdinalIgnoreCase);
        }

        public void AgregarEquipo(string nombreEquipo)
        {
            if (!Equipos.ContainsKey(nombreEquipo))
            {
                Equipos[nombreEquipo] = new Equipo(nombreEquipo);
                Console.WriteLine($"Equipo {nombreEquipo} creado exitosamente.");
            }
            else
            {
                Console.WriteLine($"El equipo {nombreEquipo} ya existe.");
            }
        }

        public void AgregarJugadorAEquipo(string nombreEquipo, Jugador jugador)
        {
            if (Equipos.ContainsKey(nombreEquipo))
            {
                Equipos[nombreEquipo].AgregarJugador(jugador);
            }
            else
            {
                Console.WriteLine($"El equipo {nombreEquipo} no existe. Primero debe crearlo.");
            }
        }

        public void MostrarTorneo()
        {
            if (Equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados en el torneo.");
                return;
            }

            foreach (var equipo in Equipos.Values)
            {
                equipo.MostrarJugadores();
                Console.WriteLine("----------------------------");
            }
        }

        public void MostrarEquipo(string nombreEquipo)
        {
            if (Equipos.ContainsKey(nombreEquipo))
            {
                Equipos[nombreEquipo].MostrarJugadores();
            }
            else
            {
                Console.WriteLine($"El equipo {nombreEquipo} no existe.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Torneo torneo = new Torneo();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ TORNEO DE FÚTBOL ---");
                Console.WriteLine("1. Crear equipo");
                Console.WriteLine("2. Agregar jugador a equipo");
                Console.WriteLine("3. Mostrar equipo");
                Console.WriteLine("4. Mostrar todos los equipos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del equipo: ");
                        string nombreEquipo = Console.ReadLine();
                        torneo.AgregarEquipo(nombreEquipo);
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre del equipo: ");
                        string equipoJugador = Console.ReadLine();
                        Console.Write("Nombre del jugador: ");
                        string nombreJugador = Console.ReadLine();
                        Console.Write("Número del jugador: ");
                        int numeroJugador;
                        while(!int.TryParse(Console.ReadLine(), out numeroJugador))
                        {
                            Console.Write("Ingrese un número válido: ");
                        }
                        Console.Write("Posición del jugador: ");
                        string posicionJugador = Console.ReadLine();

                        Jugador jugador = new Jugador(nombreJugador, numeroJugador, posicionJugador);
                        torneo.AgregarJugadorAEquipo(equipoJugador, jugador);
                        break;

                    case "3":
                        Console.Write("Ingrese el nombre del equipo: ");
                        string equipoMostrar = Console.ReadLine();
                        torneo.MostrarEquipo(equipoMostrar);
                        break;

                    case "4":
                        torneo.MostrarTorneo();
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }
    }
}
