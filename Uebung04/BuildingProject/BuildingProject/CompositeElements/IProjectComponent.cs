namespace BuildingProject.CompositeElements;

public interface IProjectComponent
{
    public string Name { get; set; }
    string GetDetails();
}