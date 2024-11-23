using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Словарь для сопоставления слов и цифр
        Dictionary<string, int> wordToDigit = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите слово, представляющее цифру от zero до nine (или 'exit' для выхода):");
            string input = Console.ReadLine();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            if (wordToDigit.TryGetValue(input, out int digit))
            {
                Console.WriteLine($"Введенное слово соответствует цифре: {digit}");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный ввод. Попробуйте снова.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
