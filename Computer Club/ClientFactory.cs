namespace Computer_Club;

public class ClientFactory
{

    private const int MinMoney = 0;
    private const int MaxMoney = 3000;
    private readonly Random _random =new Random();

 
    public Client CreateClient()
    {
        var money = _random.Next(MinMoney, MaxMoney);
        var client = new Client(money, _random);
        return client;
    }
}