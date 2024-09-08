using ÜbungSEW;

namespace Adapter;

public class HonkAdapter : IQuackable
{
    private readonly IHonkable _honkable;

    public HonkAdapter(IHonkable honkable)
    {
        _honkable = honkable;
    }

    public string Quack()
    {
        return _honkable.Honk();
    }
}