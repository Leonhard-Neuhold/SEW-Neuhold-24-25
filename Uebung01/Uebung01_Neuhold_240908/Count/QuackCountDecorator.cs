using ÜbungSEW;

namespace Count;

public class QuackCountDecorator : IQuackable
{
    private readonly IQuackable _quackable;

    public static int counter = 0;

    public QuackCountDecorator(IQuackable quackable)
    {
        _quackable = quackable;
    }
    
    public string Quack()
    {
        counter++;
        return _quackable.Quack();
    }
}