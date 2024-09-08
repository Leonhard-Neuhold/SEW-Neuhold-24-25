namespace ÜbungSEW;

public abstract class ADuck : IFlyable, IQuackable
{
    protected IQuackable _quackable;
    protected IFlyable _flyable;

    public static int counter = 0;
    
    public ADuck(IQuackable quackable, IFlyable flyable)
    {
        _quackable = quackable;
        _flyable = flyable;
    }

    public ADuck()
    {
        
    }
    
    public string Fly()
    {
        return _flyable.Fly();
    }

    public string Quack()
    {
        counter++;
        return _quackable.Quack();
    }
}