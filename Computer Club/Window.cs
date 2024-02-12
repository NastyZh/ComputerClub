using SFML.Graphics;
using SFML.Window;

namespace Computer_Club;

public class Window
{
    private const int WIDTH = 640;
    private const int HEIGHT = 480;
    private const string TITLE = "Computer Club";
    private RenderWindow _window;
    
  

    public Window()
    {
        var mode = new VideoMode(WIDTH, HEIGHT);
        _window = new RenderWindow(mode, TITLE);
            
        _window.SetVerticalSyncEnabled(true);
        _window.Closed += (_, _) => _window.Close();
    }
    public void Run()
    {
        
        while (_window.IsOpen)
        {
            HandleEvents();
            Update();
            Draw();
        }
    }

    private void HandleEvents()
    {
        _window.DispatchEvents();
    }

    private void Update()
    {
        
    }

    private void Draw()
    {
        _window.Clear(Color.Blue);
        _window.Display();
    }
}