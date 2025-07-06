// =============================
// - EJERCICIO 6
// REGISTRO DE ESTUDIANTES
// =============================

public class Estudiante
{
    public string Cedula;
    public string Nombre;
    public string Apellido;
    public string Correo;
    public double Nota;
    public Estudiante Siguiente;

    public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Nota = nota;
        Siguiente = null;
    }
}
