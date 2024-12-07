// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

for (int i = 0; i < 2; i++)
    new Thread(Sentinel.Run).Start();

for (int i = 0; i < 4; i++)
    new Thread(Harvester.Run).Start();

class Sentinel
{
    public static readonly SemaphoreSlim SemSentinel = new SemaphoreSlim(0);

    public static void Run()
    {
        while (true)
        {
            ScanSurface();
            Signal();
            Harvester.SemHarvester.Release();
            SemSentinel.Wait();
        }
    }
    
    static void ScanSurface()
    {
        Thread.Sleep(500);
        Console.WriteLine("Scanned surface");
    }

    static void Signal()
    {
        Thread.Sleep(800);
        Console.WriteLine("Sent signal");
    }
}


class Harvester
{
    public static readonly SemaphoreSlim SemHarvester = new SemaphoreSlim(0);
    public static readonly SemaphoreSlim SemStore = new SemaphoreSlim(2);

    public static void Run()
    {
        while (true)
        {
            SemHarvester.Wait();
            Acknowledge();
            Sentinel.SemSentinel.Release();
            Harvest();
            SemStore.Wait();
            Store();
            SemStore.Release();
            Console.WriteLine("...");
        }
    }

    static void Acknowledge()
    {
        Thread.Sleep(100);
        Console.WriteLine("Acknowledged");
    }

    static void Harvest()
    {
        Thread.Sleep(1000);
        Console.WriteLine("Harvested");
    }

    static void Store()
    {
        Thread.Sleep(200);
        Console.WriteLine("Stored");
    }
    
}