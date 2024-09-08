namespace ÜbungSEW;

public class Rubberduck : ADuck
{
    public Rubberduck(IQuackable quackable, IFlyable flyable) : base(quackable, flyable)
    {
    }

    public Rubberduck()
    {
        _quackable = new Squeaking();
        _flyable = new NotFlying();
    }
}