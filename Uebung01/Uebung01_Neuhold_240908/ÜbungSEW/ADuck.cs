namespace ÜbungSEW;

public abstract class ADuck : IFlyable, IQuackable
{
    protected IQuackable _quackable;
    protected IFlyable _flyable;
    
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
        return _quackable.Quack();
    }
}