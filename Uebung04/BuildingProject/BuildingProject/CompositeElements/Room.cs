using BuildingProject.Logger;

namespace BuildingProject.CompositeElements;

public class Room : ACompositeElement
{
    public Room(string name)
    {
        MyLogger.Instance.Log($"Room {name} created");
        Name = name;
    }

    public override void Add(IProjectComponent component)
    {
        MyLogger.Instance.Log($"Room {Name} added");
        Children.Add(component);
    }
}