using System;

namespace FigurasGeometricas
{
    // Clase Círculo que representa un círculo con su radio
    public class Circulo
    {
        // Campo privado que almacena el radio del círculo
        private double radio;

        // Constructor para inicializar el radio
        public Circulo(double r)
        {
            radio = r;
        }

        // Método para calcular el área de un círculo
        // Fórmula: π * radio^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro (circunferencia)
        // Fórmula: 2 * π * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectángulo que representa un rectángulo con base y altura
    public class Rectangulo
    {
        // Campos privados que almacenan la base y la altura del rectángulo
        private double baseRect;
        private double altura;

        // Constructor para inicializar base y altura
        public Rectangulo(double b, double h)
        {
            baseRect = b;
            altura = h;
        }

        // Método para calcular el área del rectángulo
        // Fórmula: base * altura
        public double CalcularArea()
        {
            return baseRect * altura;
        }

        // Método para calcular el perímetro del rectángulo
        // Fórmula: 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (baseRect + altura);
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            // Crear un objeto Círculo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

            // Crear un objeto Rectángulo con base 4 y altura 6
            Rectangulo miRectangulo = new Rectangulo(4, 6);
            Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
        }
    }
}
