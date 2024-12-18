﻿// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Cook abdul = new Cook("Abdul");
Cook hakan = new Cook("Hakan");
Cashier ali = new Cashier("Ali");

new Thread(new Customer("chefe").Run).Start();
new Thread(new Customer("customer").Run).Start();

new Thread(abdul.Run).Start();
new Thread(hakan.Run).Start();
new Thread(ali.Run).Start();



class Person(string name)
{
    public string Name { get; } = name;
}

class Customer(string name) : Person(name)
{
    public static readonly SemaphoreSlim SemCustomer = new(0);

    public void Run()
    {
        while (true)
        {
            Order();
            Cook.SemCook.Release();
            SemCustomer.Wait();
            Pay();
            Cashier.SemCashier.Release();
            SemCustomer.Wait();
        }
    }

    void Order()
    {
        Console.WriteLine($"{Name} is ordering");
        Thread.Sleep(1917);
    }

    void Pay()
    {
        Console.WriteLine($"{Name} is paying");
        Thread.Sleep(1989);
    }
}

class Cashier(string name) : Person(name)
{
    public static readonly SemaphoreSlim SemCashier = new(0);

    public void Run()
    {
        while (true)
        {
            SemCashier.Wait();
            Confirm();
            Customer.SemCustomer.Release();
        }
    }

    void Confirm()
    {
        Console.WriteLine($"{Name} is confirming a payment");
        Thread.Sleep(1818);
    }
}

class Cook(string name) : Person(name)
{
    public static readonly SemaphoreSlim SemCook = new(0);

    public void Run()
    {
        while (true)
        {
            SemCook.Wait();
            PrepareMeal();
            Customer.SemCustomer.Release();
        }
    }

    void PrepareMeal()
    {
        Console.WriteLine($"{Name} is preparing a meal");
        Thread.Sleep(1818);
    }
}