namespace Window;

public class WindowWithCurtains : WindowDecorator
{
    public WindowWithCurtains(IWindow window) : base(window)
    { }

    public override string GetDescription()
    {
        return $"{_window.GetDescription()}, " + "with curtains";
    }

    public override double GetCost()
    {
        return _window.GetCost() + 50.0;
    }
}