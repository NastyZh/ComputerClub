using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Computer_Club;
using SFML;

public class SFMLUserInterface : IUserInterface
{
    private readonly RenderWindow _window;

    private Text _text;
    private Font _font;
    private const string FONT_PATH = "D:\\Мои проекты\\Computer Club\\Assets\\Assets\\Fonts\\FreeMonospaced.ttf";
    public float CurrentY { get; set; }
    private bool _isInputReceived = false;
    private string _currentChoice;

    
    

    public SFMLUserInterface(RenderWindow window)
    {
        _window = window;
        _font = new Font(FONT_PATH);
        _text = new Text("", _font, 20);
        _window.TextEntered += OnTextEntered;
    }

    private void OnTextEntered(object? sender, TextEventArgs eventData)
    {
        // _currentChoice = eventData.Unicode;
        
        if (eventData.Unicode.Length > 0 && eventData.Unicode[0] >= 32 && eventData.Unicode[0] < 128)
        {
            
            _currentChoice =eventData.Unicode[0].ToString();
            _isInputReceived = true;
        }
    }
    

    public void ShowClubBalance(int balance)
    {
        DrawText($"Баланс компьютерного клуба {balance} руб.", 10);
    }


    public void ShowClientRequest(int desiredMinutes)
    {
        DrawText($"Клиент хочет забронировать компьютер на {desiredMinutes} минут.", 10);
    }

    public void ShowClientBalance(int money)
    {
        DrawText($"На счете клиента доступно {money} руб.", 10);
    }

    public void ResetTextPosition()
    {
        CurrentY = 10;
    }

    public int GetComputerChoice(int computersCount)
    {
        
        DrawText($"Выберите компьютер:", 10);
        
        while (!_isInputReceived)
        {
            _window.DispatchEvents();
        }
        if (int.TryParse(_currentChoice, out var computerNumber) && computerNumber >= 1 && computerNumber <= computersCount)
        {
            _isInputReceived = false;
            return computerNumber - 1;
        }

        return -1;
    }

    public void ShowInvalidChoice(int computersCount)
    {
        DrawText("Неверный выбор компьютера.",10);
    }
    //добавила входные данные - string count
    public void ShowComputerTaken(int count)
    {
        DrawText($"В данный момент компьютер занят на {count} минут.",10);
    }

    public void ShowClientServed(int computerNumber)
    {
        DrawText($"Клиент забронировал компьютер {computerNumber}",10);
    }

    public void ShowClientNotServed()
    { 
        DrawText("Не удалось забронировать компьютер.",10);
    }
    
    public void ShowComputerState(Computer computer, int computerNumber)
    {
         
        if (computer.IsTaken)
        {
            DrawText($"Компьютер {computerNumber+1} занят. Осталось  {computer.MinutesRemaining} минут.", 10);
            return;
        }

        DrawText($"Компьютер {computerNumber+1} свободен. Цена за минуту : {computer.PricePerMinute}",10);
    }

    public void ShowLineSeparator()
    {
        DrawText("------------------------------",100);
    }
   
  
    private void DrawText(string text, float x)
    {
        
        _text.DisplayedString = text;
        _text.FillColor = Color.White;
        

        _text.Position = new Vector2f(x, CurrentY);
     
        CurrentY += 20;
        
        _window.Draw(_text);
        _window.Display();
    }
   
  
}