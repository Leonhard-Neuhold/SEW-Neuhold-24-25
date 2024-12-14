// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

new Thread(new MachineA().Run).Start();
new Thread(new MachineB().Run).Start();
new Thread(new ConveyorBelt().Run).Start();


class MachineA
{
    public static readonly SemaphoreSlim SemA = new SemaphoreSlim(1 );
    public void Run()
    {
        while (true)
        {
            ConveyorBelt.SemMove.Wait();
            Process();
            SemA.Release();
        }
    }

    public void Process()
    {
        Thread.Sleep(100);
        Console.WriteLine("Machine A is processing...");
    }
}

class MachineB
{
    public static readonly SemaphoreSlim SemB = new SemaphoreSlim(1);
    public void Run()
    {
        while (true)
        {
            ConveyorBelt.SemMove.Wait();
            Process();
            SemB.Release();
        }
    }

    public void Process()
    {
        Thread.Sleep(150);
        Console.WriteLine("Machine B is processing...");
    }
}

class ConveyorBelt
{
    public static readonly SemaphoreSlim SemMove = new SemaphoreSlim(0);
    public void Run()
    {
        Move();
        MachineA.SemA.Wait();
        SemMove.Release();
        while (true)
        {
            MachineA.SemA.Wait();
            MachineB.SemB.Wait();
            Move();
            SemMove.Release();
            SemMove.Release();
        }
    }

    public void Move()
    {
        Console.WriteLine("Moving...");
    }
}