using BuildingProject.Logger;

namespace BuildingProject.CompositeElements;

public class Material : ALeafElement
{
    public Material(string name)
    {
        MyLogger.Instance.Log($"Material {name} created");
        Name = name;
    }
}