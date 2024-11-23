using System;

class ForeignPassport
{
    private string passportNumber;
    private string fullName;
    private DateTime issueDate;
    private DateTime expirationDate;
    private string issuingAuthority;

    public string PassportNumber
    {
        get => passportNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 9 || !IsValidPassportNumber(value))
            {
                throw new ArgumentException("Неверный номер паспорта. Он должен состоять из 9 цифр.");
            }
            passportNumber = value;
        }
    }

    public string FullName
    {
        get => fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("ФИО не может быть пустым.");
            }
            fullName = value;
        }
    }

    public DateTime IssueDate
    {
        get => issueDate;
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Дата выдачи не может быть в будущем.");
            }
            issueDate = value;
        }
    }

    public DateTime ExpirationDate
    {
        get => expirationDate;
        set
        {
            if (value <= IssueDate)
            {
                throw new ArgumentException("Дата окончания действия должна быть позже даты выдачи.");
            }
            expirationDate = value;
        }
    }

    public string IssuingAuthority
    {
        get => issuingAuthority;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Орган выдачи не может быть пустым.");
            }
            issuingAuthority = value;
        }
    }
    public ForeignPassport(string passportNumber, string fullName, DateTime issueDate, DateTime expirationDate, string issuingAuthority)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
        IssuingAuthority = issuingAuthority;
    }

    private bool IsValidPassportNumber(string number)
    {
        foreach (char c in number)
        {
            if (!char.IsDigit(c)) return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"Паспорт: {PassportNumber}\nФИО: {FullName}\nДата выдачи: {IssueDate:dd.MM.yyyy}\nДата окончания: {ExpirationDate:dd.MM.yyyy}\nОрган выдачи: {IssuingAuthority}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите номер паспорта:");
            string passportNumber = Console.ReadLine();

            Console.WriteLine("Введите ФИО:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите дату выдачи (в формате ГГГГ-ММ-ДД):");
            DateTime issueDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите дату окончания действия (в формате ГГГГ-ММ-ДД):");
            DateTime expirationDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите орган выдачи:");
            string issuingAuthority = Console.ReadLine();

            // Создание экземпляра класса
            ForeignPassport passport = new ForeignPassport(passportNumber, fullName, issueDate, expirationDate, issuingAuthority);

            Console.WriteLine("\nИнформация о паспорте:");
            Console.WriteLine(passport);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
