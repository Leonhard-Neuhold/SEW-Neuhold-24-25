using Adapter;
using Count;
using ÜbungSEW;

namespace Test;

public class Tests
{
    private List<IQuackable> _quackables;
    private List<IQuackable> _quackables2;
    private List<IFlyable> _flyables;
    private List<IQuackable> _count;
    
    [SetUp]
    public void Setup()
    {
        _quackables = new ()
        {
            new Mallardduck(),
            new Redheadduck(),
            new Decoyduck(),
            new Rubberduck()
        };
        _quackables2 = new ()
        {
            new Mallardduck(),
            new Redheadduck(),
            new Decoyduck(),
            new Rubberduck(),
            new HonkAdapter(new Goose()),
            new CackleAdapter(new Chicken())
        };
        _flyables = new()
        {
            new Mallardduck(),
            new Redheadduck(),
            new Decoyduck(),
            new Rubberduck()
        };
        _count = new ()
        {
            new Mallardduck(),
            new Redheadduck(),
            new Decoyduck(),
            new Rubberduck()
        };
    }

    [Test]
    public void Quack()
    {
        var data = _quackables.Select(d => d.Quack()).ToList();

        foreach (var duck in data)
        {
            Console.WriteLine(duck);
        }
        Assert.Pass();
    }
    
    [Test]
    public void Fly()
    {
        var data = _flyables.Select(d => d.Fly()).ToList();

        foreach (var duck in data)
        {
            Console.WriteLine(duck);
        }
        Assert.Pass();
    }
    
    [Test]
    public void Adapter()
    {
        var data = _quackables2.Select(d => d.Quack()).ToList();

        foreach (var duck in data)
        {
            Console.WriteLine(duck);
        }
        Assert.Pass();
    }

    [Test]
    public void Count()
    {
        var data = _count.Select(d => d.Quack()).ToList();
        
        Assert.That(data.Count, Is.EqualTo(4));
    }
    
    [Test]
    public void CountExtension()
    {
        var data = _count.Select(d => d.QuackAndCount()).ToList();
        
        Assert.That(data.Count, Is.EqualTo(4));
    }
}