﻿// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

   
for (int i = 0; i < 20; i++)
    new Thread(new Ship() {Id = i}.Run).Start();
new Thread(new StagingArea().Run).Start();


public class StagingArea
{
    public static readonly SemaphoreSlim SemStagingArea = new(5);
    
    
    public void Run()
    {
        while(true)
        {
            // 5 ships into harbour
            SemStagingArea.Wait();
            Signal();
            // ship to unload
            Ship.SemHandshake.Release();
        }
    }
    
    private void Signal()
    {
        Console.WriteLine("Stagingarea: signaling ship");
    }
}

public class Ship 
{
    public static readonly SemaphoreSlim SemShipGuard = new(3);
    public static readonly SemaphoreSlim SemHandshake = new(0);
    public int Id { get; set; }

    public void Run()
    {
        while (true)
        {
            // wait for signal to unload
            SemHandshake.Wait();
            // unload 3 ships at a time
            SemShipGuard.Wait();
            Unload();
            // let 1 more ship unload
            SemShipGuard.Release();
            // let 1 more ship into the harbour
            StagingArea.SemStagingArea.Release();
            
        }
    }

    private void Unload()
    {
        Thread.Sleep(500);
        Console.WriteLine($"unloading ship: {Id}");
    }

}