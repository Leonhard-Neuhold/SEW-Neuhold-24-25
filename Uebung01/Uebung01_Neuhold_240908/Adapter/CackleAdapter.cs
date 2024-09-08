using ÜbungSEW;

namespace Adapter;

public class CackleAdapter : IQuackable
{
    private readonly ICackleable _cackleable;

    public CackleAdapter(ICackleable cackleable)
    {
        _cackleable = cackleable;
    }
    
    public string Quack()
    {
        return _cackleable.Cackle();
    }
}