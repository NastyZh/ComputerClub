namespace Computer_Club;

public class ConsoleUserInterface:IUserInterface
{
    

    public void ShowClubBalance(int balance)
    {
        Console.WriteLine($"Общий баланс клуба {balance}. ");
    }

    public void ShowClientRequest(int desiredMinutes)
    {
        Console.WriteLine($"Клиент хочет забронировать компьютер на {desiredMinutes} минут.");
    }

    public void ShowClientBalance(int money)
    {
        Console.WriteLine($"На счете клиента доступно {money} руб.");
    }

    public int GetComputerChoice(int computersCount)
    {
        Console.WriteLine($"Выберите компьютер:");
        var input= Console.ReadLine();
        if (int.TryParse(input,out var computerNumber) && computerNumber>=1 && computerNumber<=computersCount)
        {
            return computerNumber-1;
        }

        return -1;
    }

    public void ShowInvalidChoice(int computersCount)
    {
        Console.WriteLine("Неверный выбор компьютера.");
    }
    //добавила входные данные - string count
    public void ShowComputerTaken(int count)
    {
        Console.WriteLine($"В данный момент компьютер занят на {count} минут.");
    }

    public void ShowClientServed(int computerNumber)
    {
        Console.WriteLine($"Клиент забронировал компьютр {computerNumber+1}");
    }

    public void ShowClientNotServed()
    {
        Console.WriteLine("Не удалось забронировать компьютер.");
    }

    public void ShowComputerState(Computer computer, int computerNumber)
    {
        
        if (computer.IsTaken)
        {
            Console.WriteLine($"Компьютер {computerNumber+1} занят. Осталось  {computer.MinutesRemaining} минут.");
            return;
        }

        Console.WriteLine($"Компьютер {computerNumber+1} свободен. Цена за минуту : {computer.PricePerMinute}");
    }

    public void ShowLineSeparator()
    {
       Console.WriteLine("---------------------");
    }
}