namespace Computer_Club;

public class ClientManager
{
    public bool HasClients=>_clients.Count>0;
    private readonly Queue<Client?> _clients=new Queue<Client?>();
    private readonly ClientFactory _clientFactory;
    
    
    public ClientManager(int initialClientsCount, ClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        InitializeClients(initialClientsCount);
    }

  
    public void AddNewClient( )
    {
       var client= _clientFactory.CreateClient();
        _clients.Enqueue(client);
    }

    public Client? GetNextClient()
    {
        return HasClients ? _clients.Dequeue() : null;
    }

    private void InitializeClients(int initialClientsCount)
    {
        for (int i = 0; i < initialClientsCount; i++)
        {
            var client = _clientFactory.CreateClient();
            _clients.Enqueue(client);

        }
    }
    
    

    
}