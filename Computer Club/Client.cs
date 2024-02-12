namespace Computer_Club;

public class Client
{
  public int DesiredMinutes { get; }// желаемое количество минут использования 
  public int Money { get; private set; }

  private const int MinDesiredMinutes = 10;
  private const int MaxDesiredMinutes = 50;
  private int _moneyToPay;

  public Client(int money, Random random)
  {
      Money = money;
      DesiredMinutes = random.Next(MinDesiredMinutes,MaxDesiredMinutes);
  }

  public bool CheckSolvency(Computer computer) //проверка платежеспособности.
  {
      _moneyToPay = computer.PricePerMinute * DesiredMinutes;
      return _moneyToPay <= Money;
  }

  public int Pay()
  {
      if (_moneyToPay <= Money && _moneyToPay!=0)
      {
          Money -= _moneyToPay;
          return _moneyToPay;
      }
     
      return 0;
  }
}