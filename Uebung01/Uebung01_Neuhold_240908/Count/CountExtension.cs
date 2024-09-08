using ÜbungSEW;

namespace Count;

public static class CountExtension
{
    public static int Counter = 0;

    public static string QuackAndCount(this IQuackable _quackable)
    {
        Counter++;
        return _quackable.Quack();
    }
}