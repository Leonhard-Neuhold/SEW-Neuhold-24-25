// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


new Thread(new F1Race().Run).Start();
for (int i = 0; i < Extensions.CountRacers; i++)
    new Thread(new Car($"Racer {i}").Run).Start();


public class Car
{
    public static readonly SemaphoreSlim SemCar = new(0, 5);
    public static readonly SemaphoreSlim SemPitstop = new(3);
    public string Racer { get; set; }

    public Car(string racer)
    {
        Racer = racer;
    }

    public void Run()
    {
        WaitForSignal();
        SemCar.Wait();
        Race();
        SemPitstop.Wait();
        TakingPitstop();
        SemPitstop.Release();
        Race();
        F1Race.SemRace.Release();
    }

    private void WaitForSignal()
    {
        Console.WriteLine($"{Racer}: Waiting for Start Signal");
        Thread.Sleep(200);
    }

    private void Race()
    {
        Console.WriteLine($"{Racer}: Racing");
        Thread.Sleep(1500);
    }

    private void TakingPitstop()
    {
        Console.WriteLine($"{Racer}: Taking Pit stop");
        Thread.Sleep(500);
    }
}



public class F1Race
{
    public static readonly SemaphoreSlim SemRace = new(Extensions.CountRacers);
    
    public void Run()
    {
        Start();
        for (int i = 0; i < Extensions.CountRacers; i++)
            Car.SemCar.Release();
        SemRace.Wait();
        while (true)
        {
            if (SemRace.CurrentCount == Extensions.CountRacers)
                End();
        }
        
    }

    private void Start()
    {
        Console.WriteLine("Starting Race");
        Thread.Sleep(1000);
    }

    private void End()
    {
        Console.WriteLine("Race finished");
    }
}

public static class Extensions
{
    public static int CountRacers = 5;
}
