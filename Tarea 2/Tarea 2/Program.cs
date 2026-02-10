// Lenny Nuñez 2025-1878
using System;

class Program
{
    static void Main()
    {
        Console.Write("Escribe un número: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("El número es par.");
            }
            else
            {
                Console.WriteLine("El número es impar.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Debes escribir un número entero.");
        }
    }
}