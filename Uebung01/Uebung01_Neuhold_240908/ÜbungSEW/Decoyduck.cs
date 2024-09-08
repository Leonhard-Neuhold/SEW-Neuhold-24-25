namespace ÜbungSEW;

public class Decoyduck : ADuck
{
    public Decoyduck(IQuackable quackable, IFlyable flyable) : base(quackable, flyable)
    {
    }

    public Decoyduck()
    {
        _quackable = new NotQuacking();
        _flyable = new NotFlying();
    }
}