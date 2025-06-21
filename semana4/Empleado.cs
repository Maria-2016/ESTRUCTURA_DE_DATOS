// Clase que representa un empleado
public class Empleado
{
    private string nombre;
    private string cedula;
    private List<Aporte> aportes; // Lista de aportes

    public Empleado(string nombre, string cedula)
    {
        this.nombre = nombre;
        this.cedula = cedula;
        this.aportes = new List<Aporte>();
    }

    public string GetCedula()
    {
        return cedula;
    }

    // Método para agregar un nuevo aporte
    public void AgregarAporte(string fecha, float monto)
    {
        aportes.Add(new Aporte(fecha, monto));
    }

    // Método para mostrar todos los aportes del empleado
    public void MostrarAportes()
    {
        try
        {
            Console.WriteLine($"\nEmpleado: {nombre} | Cédula: {cedula}");
            if (aportes.Count == 0)
            {
                Console.WriteLine("  No tiene aportes registrados.");
            }
            else
            {
                foreach (var aporte in aportes)
                {
                    Console.WriteLine($"  Fecha: {aporte.Fecha} | Monto: ${aporte.Monto}");
                }
            }
        }
        catch (Exception err)
        {
            Console.WriteLine($"{err.Message}");
         
        }

    }
}
