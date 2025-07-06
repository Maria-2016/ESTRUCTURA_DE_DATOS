//Lista Enlazada
using System;

public class ListaEstudiantes
{
    public Estudiante Cabeza;

    // Agrega estudiante: al inicio si aprueba (nota >= 7), al final si reprueba
    public void Agregar(Estudiante nuevo)
    {
        if (nuevo.Nota >= 7) // Aprobado: se inserta por el inicio
        {
            nuevo.Siguiente = Cabeza;
            Cabeza = nuevo;
        }
        else // Reprobado: se inserta por el final
        {
            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                Estudiante actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }
    }

    // Buscar estudiante por cédula
    public Estudiante Buscar(string cedula)
    {
        Estudiante actual = Cabeza;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
                return actual;
            actual = actual.Siguiente;
        }
        return null;
    }

    // Eliminar estudiante por cédula
    public bool Eliminar(string cedula)
    {
        if (Cabeza == null) return false;

        if (Cabeza.Cedula == cedula)
        {
            Cabeza = Cabeza.Siguiente;
            return true;
        }

        Estudiante actual = Cabeza;
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.Cedula == cedula)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            actual = actual.Siguiente;
        }
        return false;
    }

    // Contar aprobados y reprobados
    public void ContarAprobadosReprobados(out int aprobados, out int reprobados)
    {
        aprobados = 0;
        reprobados = 0;

        Estudiante actual = Cabeza;
        while (actual != null)
        {
            if (actual.Nota >= 7)
                aprobados++;
            else
                reprobados++;
            actual = actual.Siguiente;
        }
    }

    // Mostrar todos los estudiantes
    public void MostrarTodos()
    {
        Estudiante actual = Cabeza;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Cedula} - {actual.Nombre} {actual.Apellido} - {actual.Correo} - Nota: {actual.Nota}");
            actual = actual.Siguiente;
        }
    }
}
