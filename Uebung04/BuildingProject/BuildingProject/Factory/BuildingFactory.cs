using BuildingProject.CompositeElements;
using BuildingProject.Logger;

namespace BuildingProject.Factory;

public class BuildingFactory : IProjectElementFactory
{
    public IProjectElement Create(Project.Project project, string name)
    {
        MyLogger.Instance.Log($"Creating new building...");
        return new Building(project, name);
    }
}