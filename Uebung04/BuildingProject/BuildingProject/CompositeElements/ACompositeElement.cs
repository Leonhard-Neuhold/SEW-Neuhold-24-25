using BuildingProject.Logger;

namespace BuildingProject.CompositeElements;

public abstract class ACompositeElement : IProjectComponent
{
    public string Name { get; set; }
    public List<IProjectComponent> Children { get; set; }

    public ACompositeElement()
    {
        Children = new List<IProjectComponent>();
    }

    public abstract void Add(IProjectComponent component);

    public void Remove(IProjectComponent component)
    {
        MyLogger.Instance.Log("Removing child...");
        Children.Remove(component);
    }

    public string GetDetails()
    {
        return $"Name: {Name}\nChildren:\n{string
            .Join("\n", Children
                .Select(c => c.GetDetails()))}";
    }
}