namespace ÜbungSEW;

public class Redheadduck : ADuck
{
    public Redheadduck(IQuackable quackable, IFlyable flyable) : base(quackable, flyable)
    {
    }

    public Redheadduck()
    {
        _quackable = new Quacking();
        _flyable = new Flying();
    }
}