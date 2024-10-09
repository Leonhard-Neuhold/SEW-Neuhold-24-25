namespace BuildingProject.CompositeElements;

public interface IProjectElement
{
    string Name { get; set; }
    Project.Project Project { get; set; }
}