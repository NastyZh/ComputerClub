namespace Computer_Club;

public class Computer
{
    public bool IsTaken=>MinutesRemaining>0;
    public int PricePerMinute { get; }

    public int MinutesRemaining { get; private set; }

    private Client _client;
    //количество минут, оставшихся для использования компьютера текущим клиентом. По умолчанию равно 0, что также означает, что компьютер свободен.


    public Computer(int pricePerMinute)
    {
        PricePerMinute = pricePerMinute;
    }

    public void BecomeTaken(Client client)
    {
        _client = client;
        MinutesRemaining = _client.DesiredMinutes;
    }

    public void SpendOneMinute()
    {
        if (IsTaken)
        {
            MinutesRemaining -= 1;
        }
        
    }

   
}