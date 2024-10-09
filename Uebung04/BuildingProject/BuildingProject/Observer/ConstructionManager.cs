using BuildingProject.Logger;

namespace BuildingProject.Observer;

public class ConstructionManager : IProjectObserver
{
    private List<string> notifications = new List<string>();

    public string GetNotifications()
    {
        return string
            .Join('\n', notifications);
    }
    public void Update(string message)
    {
        MyLogger.Instance.Log("Sending notifications to Construction Manager");
        notifications.Add($"Construction Manager notified: {message}");
    }
}