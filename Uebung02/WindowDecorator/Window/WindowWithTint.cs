namespace Window;

public class WindowWithTint : WindowDecorator
{
    public WindowWithTint(IWindow window) : base(window)
    { }

    public override string GetDescription()
    {
        return $"{_window.GetDescription()}, " + "with tinted glass";
    }

    public override double GetCost()
    {
        return _window.GetCost() + 40.0;
    }
}