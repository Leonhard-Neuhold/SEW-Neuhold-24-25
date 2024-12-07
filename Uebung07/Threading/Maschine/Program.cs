// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

new Thread(MaschineA.Run).Start();
new Thread(MaschineB.Run).Start();
new Thread(Crane.Run).Start();  

class MaschineA
{
    public static readonly SemaphoreSlim SemA = new SemaphoreSlim(0);
    
    public static void Run()
    {
        while (true)
        {
            SemA.Wait();
            Process();
            Crane.semC.Release();
        }
    }

    static void Process()
    {
        Thread.Sleep(500);
        Console.WriteLine("A finished the work!");
    }
}

class MaschineB
{
    public static readonly SemaphoreSlim SemB = new SemaphoreSlim(0);
    
    public static void Run()
    {
        while (true)
        {
            SemB.Wait();
            Process();  
            Crane.semC.Release();
        }
    }
    
    static void Process()
    {
        Thread.Sleep(1000);
        Console.WriteLine("B finished the work!");
    }
}

class Crane
{
    public static SemaphoreSlim semC = new SemaphoreSlim(0);
    
    public static void Run()
    {
        while (true)
        {
            Move("Lager", "Maschine A");
            MaschineA.SemA.Release();
            semC.Wait();
            Move("Maschine A", "Maschine B");
            MaschineB.SemB.Release();
            semC.Wait();
            Move("Maschine B", "Lager");
        }
    }    
    
    static void Move(string from, string to)
    {
        Thread.Sleep(750);
        Console.WriteLine($"Moved from {from} to {to}");
    }
}