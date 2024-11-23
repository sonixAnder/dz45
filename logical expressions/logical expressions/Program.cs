using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите логическое выражение (например, 3>2 или 7<=3). Для выхода введите 'exit':");
            string input = Console.ReadLine();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Выход из программы.");
                break;
            }

            try
            {
                bool result = EvaluateLogicalExpression(input);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static bool EvaluateLogicalExpression(string expression)
    {
        string[] operators = { "<=", ">=", "<", ">", "==", "!=" };

        foreach (string op in operators)
        {
            if (expression.Contains(op))
            {
                string[] parts = expression.Split(new[] { op }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    throw new ArgumentException("Некорректный формат выражения.");
                }

                if (!int.TryParse(parts[0].Trim(), out int leftOperand) || !int.TryParse(parts[1].Trim(), out int rightOperand))
                {
                    throw new ArgumentException("Операнды должны быть целыми числами.");
                }

                return op switch
                {
                    "<" => leftOperand < rightOperand,
                    ">" => leftOperand > rightOperand,
                    "<=" => leftOperand <= rightOperand,
                    ">=" => leftOperand >= rightOperand,
                    "==" => leftOperand == rightOperand,
                    "!=" => leftOperand != rightOperand,
                    _ => throw new InvalidOperationException("Неизвестный оператор.")
                };
            }
        }
        throw new ArgumentException("Выражение не содержит допустимого оператора.");
    }
}
