using BuildingProject.Logger;

namespace BuildingProject.CompositeElements;

public class Garden : ALeafElement, IProjectElement
{
    public Project.Project Project { get; set; }

    public Garden(Project.Project project, string name)
    {
        MyLogger.Instance.Log($"Garden {name} created");
        Project = project;
        Name = name;
    }
}