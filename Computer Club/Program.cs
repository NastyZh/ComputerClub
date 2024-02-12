namespace Computer_Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientFactory = new ClientFactory();
            var clientManager = new ClientManager(25, clientFactory);
            ComputerClub computerClub = new ComputerClub(10, clientManager);
            IUserInterface userInterface = new ConsoleUserInterface();
            computerClub.Work(userInterface);
        }
    }
}