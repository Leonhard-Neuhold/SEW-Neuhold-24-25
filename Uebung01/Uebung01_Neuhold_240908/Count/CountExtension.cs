using ÜbungSEW;

namespace Count;

public static class Counter
{
    public static int count = 0;

    public static string QuackAndCount(this IQuackable quackable)
    {
        count++;
        return quackable.Quack();
    }
}