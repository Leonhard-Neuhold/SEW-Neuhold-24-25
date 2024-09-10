namespace Window;

public abstract class WindowDecorator : IWindow
{
    protected readonly IWindow _window;

    public WindowDecorator(IWindow window)
    {
        _window = window;
    }
    
    public abstract string GetDescription();

    public abstract double GetCost();
}