using Window;

namespace Test;

public class Tests
{
    private IWindow _window;
    
    [SetUp]
    public void Setup()
    {
        _window = new WindowWithTint(new WindowWithCurtains(new WindowWithBlinds(new SimpleWindow())));
    }

    [Test]
    public void WindowTest()
    {
        Assert.That("Simple window, with blinds, with curtains, with tinted glass", Is.EqualTo(_window.GetDescription()));
        Assert.That(220.0, Is.EqualTo(_window.GetCost()));
    }
}