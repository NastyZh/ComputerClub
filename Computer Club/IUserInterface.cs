namespace Computer_Club;

public interface IUserInterface
{ 
void ShowClubBalance(int balance); //`: отображение баланса клуба.

void ShowClientRequest(int desiredMinutes);//`: запрос клиента.

void ShowClientBalance(int money);//`: баланс клиента.

int GetComputerChoice(int computersCount);//`: выбор компьютера пользователем.
    
void ShowInvalidChoice(int computersCount);//`: сообщение о неверном выборе.

void ShowComputerTaken(int getStateDescription);//`: сообщение о занятом компьютере.

void ShowClientServed(int computerNumber);//`: сообщение о обслуженном клиенте.

void ShowClientNotServed();//`: сообщение о необслуженном клиенте.

void ShowComputerState(Computer computer, int computerNumber);//`: состояние компьютера.

void ShowLineSeparator();//`: разделительная линия.


}