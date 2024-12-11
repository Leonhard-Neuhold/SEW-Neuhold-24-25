// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

for (int i = 0; i < 3; i++)
    new Thread(new StagingArea().Run).Start();

for (int i = 0; i < 3; i++)
    new Thread(new Ship() {Id = i}.Run).Start();

public class StagingArea
{
    public static readonly SemaphoreSlim SemStagingArea = new(6);   
    
    public void Run()
    {
        while(true)
        {
            SemStagingArea.Wait();
            Signal();
            Ship.SemShip.Release();
        }
    }
    
    private void Signal()
    {
        Console.WriteLine("Stagingarea: signaling ship");
    }
}

public class Ship 
{
    public static readonly SemaphoreSlim SemShip = new(0);
    public int Id { get; set; }

    public void Run()
    {
        while (true)
        {
            SemShip.Wait();
            Unload();
            StagingArea.SemStagingArea.Release();
        }
    }

    private void Unload()
    {
        Thread.Sleep(500);
        Console.WriteLine($"unloading ship: {Id}");
    }

}