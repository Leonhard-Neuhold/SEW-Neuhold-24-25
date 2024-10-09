namespace BuildingProject.CompositeElements;

public abstract class ALeafElement : IProjectComponent
{
    public string Name { get; set; }

    public ALeafElement()
    {
        
    }

    protected ALeafElement(string name) : this()
    {
        Name = name;
    }

    public string GetDetails()
    {
        return Name;
    }
    
}