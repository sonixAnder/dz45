using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Калькулятор перевода чисел между системами счисления");
            Console.WriteLine("1. Из десятичной в двоичную");
            Console.WriteLine("2. Из десятичной в шестнадцатеричную");
            Console.WriteLine("3. Из двоичной в десятичную");
            Console.WriteLine("4. Из шестнадцатеричной в десятичную");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите направление перевода (1-5): ");

            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            try
            {
                string result = choice switch
                {
                    "1" => ConvertDecimalToBinary(input),
                    "2" => ConvertDecimalToHexadecimal(input),
                    "3" => ConvertBinaryToDecimal(input),
                    "4" => ConvertHexadecimalToDecimal(input),
                    _ => "Неверный выбор. Попробуйте снова."
                };

                Console.WriteLine($"Результат: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Некорректный ввод числа.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: Число вышло за пределы допустимого диапазона.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static string ConvertDecimalToBinary(string input)
    {
        if (!long.TryParse(input, out long number))
            throw new FormatException();

        return Convert.ToString(number, 2);
    }

    static string ConvertDecimalToHexadecimal(string input)
    {
        if (!long.TryParse(input, out long number))
            throw new FormatException();

        return Convert.ToString(number, 16).ToUpper();
    }

    static string ConvertBinaryToDecimal(string input)
    {
        if (!IsBinary(input))
            throw new FormatException();

        long result = Convert.ToInt64(input, 2);
        return result.ToString();
    }

    static string ConvertHexadecimalToDecimal(string input)
    {
        long result = Convert.ToInt64(input, 16);
        return result.ToString();
    }

    static bool IsBinary(string input)
    {
        foreach (char c in input)
        {
            if (c != '0' && c != '1')
                return false;
        }
        return true;
    }
}
