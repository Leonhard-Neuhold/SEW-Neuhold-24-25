using BuildingProject.CompositeElements;

namespace BuildingProject.Factory;

public interface IProjectElementFactory
{
    IProjectElement Create(Project.Project project, string name);
}