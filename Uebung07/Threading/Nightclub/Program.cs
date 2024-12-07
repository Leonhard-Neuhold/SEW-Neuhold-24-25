// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Nightclub.Test();



static class Nightclub
{
    private static readonly Semaphore _semaphore = new Semaphore(2, 3);

    static void Enter(object obj)
    {
        Console.WriteLine($"Wants to enter: {obj}");
        _semaphore.WaitOne();
        Console.WriteLine($"Entered: {obj}");
        Thread.Sleep(1000);
        Console.WriteLine($"Leaving: {obj}");
        _semaphore.Release();
    }

    public static void Test()
    {
        for (int i = 0; i < 5; i++)
        {
            new Thread(Enter).Start(i);
        }
    }
}