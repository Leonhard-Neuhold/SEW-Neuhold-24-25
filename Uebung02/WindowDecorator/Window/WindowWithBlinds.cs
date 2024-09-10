namespace Window;

public class WindowWithBlinds : WindowDecorator
{
    public WindowWithBlinds(IWindow window) : base(window)
    { }

    public override string GetDescription()
    {
        return $"{_window.GetDescription()}, " + "with blinds";
    }

    public override double GetCost()
    {
        return _window.GetCost() + 30.0;
    }
}