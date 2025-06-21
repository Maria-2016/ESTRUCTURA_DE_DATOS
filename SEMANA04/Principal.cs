public class Principal
{
    // Lista global de empleados
    private Empleado[] empleados;
    private int contador;


    public Principal(int extencion)
    {
        empleados = new Empleado[extencion];
        contador = 0;
    }

    // Función para registrar un nuevo empleado
    public void RegistrarEmpleado()
    {
        Console.Write("Ingrese nombre del empleado: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese cédula: ");
        string cedula = Console.ReadLine();

        empleados[contador++] = new Empleado(nombre, cedula);
        Console.WriteLine("Empleado registrado correctamente.");
    }

    // Función para agregar un aporte a un empleado
    public void AgregarAporteEmpleado()
    {
        Console.Write("Ingrese cédula del empleado: ");
        string cedula = Console.ReadLine();

        foreach (var emp in empleados)
        {
            if (emp.GetCedula() == cedula)
            {
                Console.Write("Ingrese fecha del aporte (dd/mm/aaaa): ");
                string fecha = Console.ReadLine();
                Console.Write("Ingrese monto del aporte: ");
                float monto = float.Parse(Console.ReadLine());

                emp.AgregarAporte(fecha, monto);
                Console.WriteLine("Aporte registrado correctamente.");
                return;
            }
        }
        Console.WriteLine("Empleado no encontrado.");
    }

    // Función para consultar aportes de un empleado por cédula
   public  void ConsultarAportes()
    {
        Console.Write("Ingrese cédula del empleado: ");
        string cedula = Console.ReadLine();

        foreach (var emp in empleados)
        {
            if (emp.GetCedula() == cedula)
            {
                emp.MostrarAportes();
                return;
            }
        }
        Console.WriteLine("Empleado no encontrado.");
    }

    // Función para listar todos los empleados y sus aportes
    public void ListarEmpleados()
    {
        if (empleados.Length == 0)
        {
            Console.WriteLine("No hay empleados registrados aún.");
            return;
        }

        foreach (var emp in empleados)
        {
            emp.MostrarAportes();
            Console.WriteLine("-----------------------------");
        }
    }

    // Método principal con menú interactivo

}