using BuildingProject.Logger;

namespace BuildingProject.CompositeElements;

public class Building : ACompositeElement, IProjectElement
{
    public Project.Project Project { get; set; }
    
    public Building(Project.Project project, string name)
    {
        MyLogger.Instance.Log($"Building {name} created");
        Project = project;
        Name = name;
    }

    public override void Add(IProjectComponent component)
    {
        if (component is Room)
        {
            if (Children.Contains(component))
            {
                return;
            }
        }
        MyLogger.Instance.Log($"Building {Name} added");
        Children.Add(component);
    }
}