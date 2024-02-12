namespace Computer_Club;

public class ComputerClub
{
    private const int PricePerMinuteMin = 10;
    private const int PricePerMinuteMax = 50;

    private int _money;

    private readonly List<Computer> _computers;
    private readonly Random _random;
    private readonly ClientManager _clientManager;
    

    public ComputerClub(int computersCount, ClientManager clientManager)
    {
        _clientManager = clientManager;
        _computers = new List<Computer>(computersCount);
        _random = new Random();
        InitializeComputers(10);
    }
   
    public void Work(IUserInterface ui) //основной рабочий метод клуба.
    {
        while (_clientManager.HasClients)
        {
            var client = _clientManager.GetNextClient();
            if (client!=null)
            {
                ProcessClient(client, ui);
                SpendOneMinute();
                ui.ShowLineSeparator();
            }
        }
    }

    private void InitializeComputers(int count) // инициализация компьютеров.
    {
        for (int i = 0; i < count; i++)
        {
            var pricePerMinute = _random.Next(PricePerMinuteMin,PricePerMinuteMax);
            var computer = new Computer(pricePerMinute);
            _computers.Add(computer);
        }
    }

    private void ProcessClient(Client client, IUserInterface ui) //обработка клиента.
    {
        
        ShowAllComputerState(ui);
        ui.ShowClientRequest(client.DesiredMinutes);
        ui.ShowClientBalance(client.Money);
        var computerNumber = ui.GetComputerChoice(_computers.Count);
        HandleClientChoice(client, computerNumber, ui);
        
    }

    private void SpendOneMinute() //уменьшение времени использования компьютеров.
    {
        for (var i = 0; i < _computers.Count; i++)
        {
            _computers[i].SpendOneMinute();
        }
    }

    private void ShowAllComputerState(IUserInterface ui) //отображение состояния всех компьютеров.
    {
        for (var i = 0; i <_computers.Count; i++)
        {
            ui.ShowComputerState(_computers[i],i);
        }
        
        ui.ShowLineSeparator();
    }

    private void HandleClientChoice(Client client, int computerNumber, IUserInterface ui) // обработка выбора клиента.
    {
        if (computerNumber < 0 || computerNumber >= _computers.Count)
        {
            ui.ShowInvalidChoice(_computers.Count);
            return;
        }

        var computer = _computers[computerNumber];
        if (computer.IsTaken)
        {
            ui.ShowComputerTaken(computer.MinutesRemaining);
            return;
        }

        if (client.CheckSolvency(computer))
        {
            _money += client.Pay();
            computer.BecomeTaken(client);
            ui.ShowClientServed(computerNumber);
            ui.ShowClubBalance(_money);
        }
        else
        {
            ui.ShowClientNotServed();
            _clientManager.AddNewClient();
        }

    }
    
    
}