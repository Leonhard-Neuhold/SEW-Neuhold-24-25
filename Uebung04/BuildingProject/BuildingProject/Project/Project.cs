using BuildingProject.CompositeElements;
using BuildingProject.Logger;
using BuildingProject.Observer;

namespace BuildingProject.Project;

public class Project
{
    private List<IProjectObserver> observers;
    private List<IProjectElement> projectElements;

    public Project()
    {
        MyLogger.Instance.Log($"Creating project...");
        observers = new List<IProjectObserver>();
        projectElements = new List<IProjectElement>();
    }

    public void CreateAndAdd<T>()
    {
        
    }
    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
    public void RegisterObserver(IProjectObserver observer)
    {
        observers.Add(observer);
    }
    public void UnregisterObserver(IProjectObserver observer)
    {
        observers.Remove(observer);
    }
}