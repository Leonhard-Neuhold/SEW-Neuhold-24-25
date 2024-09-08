namespace ÜbungSEW;

public class Mallardduck : ADuck
{
    public Mallardduck(IQuackable quackable, IFlyable flyable) : base(quackable, flyable)
    {
        
    }

    public Mallardduck()
    {
        _quackable = new Quacking();
        _flyable = new Flying();
    }
}