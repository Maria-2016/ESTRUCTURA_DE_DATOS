//6.Crear un programa que maneje el registro de los estudiantes de la unidad curricular 
//de Redes III utilizando listas enlazadas. Los estudiantes aprobados deben insertarse por el
//inicio y los reprobados por el final de la lista. Los datos requeridos por cada estudiante
//son los siguientes: cédula, nombre, apellido, correo, nota definitiva (Escala: 1-10).
// El programa debe permitir realizar las operaciones de:
//a. Agregar estudiante.
//b. Buscar estudiante por cédula.
//c. Eliminar un estudiante.
//d. Total estudiantes aprobados,
// e) total estudiantes reprobados.

using System;

class Program
{
    static void Main(string[] args)
    {
        ListaEstudiantes lista = new ListaEstudiantes();
        int opcion;

        do
        {
            Console.WriteLine("\n=== MENÚ DE ESTUDIANTES - REDES III ===");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Mostrar todos los estudiantes");
            Console.WriteLine("5. Mostrar total aprobados y reprobados");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Cédula: ");
                    string ced = Console.ReadLine();
                    Console.Write("Nombre: ");
                    string nom = Console.ReadLine();
                    Console.Write("Apellido: ");
                    string ape = Console.ReadLine();
                    Console.Write("Correo: ");
                    string cor = Console.ReadLine();
                    Console.Write("Nota (1-10): ");
                    if (double.TryParse(Console.ReadLine(), out double nota))
                    {
                        Estudiante nuevo = new Estudiante(ced, nom, ape, cor, nota);
                        lista.Agregar(nuevo);
                        Console.WriteLine("✅ Estudiante agregado.");
                    }
                    else
                    {
                        Console.WriteLine("❌ Nota inválida.");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese la cédula a buscar: ");
                    string cedBuscar = Console.ReadLine();
                    var encontrado = lista.Buscar(cedBuscar);
                    if (encontrado != null)
                        Console.WriteLine($"🔍 {encontrado.Cedula} - {encontrado.Nombre} {encontrado.Apellido} - Nota: {encontrado.Nota}");
                    else
                        Console.WriteLine("⚠️ Estudiante no encontrado.");
                    break;

                case 3:
                    Console.Write("Ingrese la cédula a eliminar: ");
                    string cedEliminar = Console.ReadLine();
                    bool eliminado = lista.Eliminar(cedEliminar);
                    Console.WriteLine(eliminado ? "🗑️ Estudiante eliminado." : "⚠️ No se encontró el estudiante.");
                    break;

                case 4:
                    Console.WriteLine("\n📋 Lista de estudiantes:");
                    lista.MostrarTodos();
                    break;

                case 5:
                    lista.ContarAprobadosReprobados(out int aprob, out int reprob);
                    Console.WriteLine($"\n📊 Aprobados: {aprob} | Reprobados: {reprob}");
                    break;

                case 0:
                    Console.WriteLine("👋 Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("❌ Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}
