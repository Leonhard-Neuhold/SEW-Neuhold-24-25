using BuildingProject.CompositeElements;
using BuildingProject.Logger;

namespace BuildingProject.Factory;

public class GardenFactory : IProjectElementFactory
{
    public IProjectElement Create(Project.Project project, string name)
    {
        MyLogger.Instance.Log($"Creating new garden...");
        return new Garden(project, name);
    }
}