

//Invertir una lista enlazada:
//Implementar un método dentro de la lista enlazada que permita invertir los datos
//almacenados en una lista enlazada, es decir que el primer elemento pase a ser el 
//último y el último pase a ser el primero, que el segundo sea el penúltimo y 
//el penúltimo pase a ser el segundo y así sucesivamente.

// Clase principal para ejecutar
class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.AgregarAlFinal(5);
        lista.AgregarAlFinal(10);
        lista.AgregarAlFinal(15);
        lista.AgregarAlFinal(20);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        lista.Invertir();
        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}
