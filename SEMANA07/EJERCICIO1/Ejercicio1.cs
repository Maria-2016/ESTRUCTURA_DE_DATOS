using System.Collections.Generic;

public static class Ejercicio1
{
    // Método que verifica si una expresión tiene paréntesis, llaves y corchetes balanceados
    public static bool EstaBalanceado(string expresion)
    {
        // Crear una pila para almacenar los símbolos de apertura
        Stack<char> pila = new Stack<char>();

        // Recorrer cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si es un símbolo de apertura, lo agregamos a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, verificamos que coincida con el último de la pila
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía no hay símbolo para cerrar
                if (pila.Count == 0)
                    return false;

                // Sacamos el último símbolo de apertura
                char tope = pila.Pop();

                // Verificamos si el par es válido
                if (!EsParejaValida(tope, c))
                    return false;
            }
        }

        // Si al final la pila está vacía, la expresión está balanceada
        return pila.Count == 0;
    }

    // Método auxiliar para validar que los símbolos de apertura y cierre coincidan
    private static bool EsParejaValida(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}
