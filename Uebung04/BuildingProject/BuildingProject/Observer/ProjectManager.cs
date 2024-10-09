using BuildingProject.Logger;

namespace BuildingProject.Observer;

public class ProjectManager : IProjectObserver
{
    private List<string> notifications = new List<string>();

    public string GetNotifications()
    {
        return string
            .Join('\n', notifications);
    }
    public void Update(string message)
    {
        MyLogger.Instance.Log("Sending notifications to Project Manager");
        notifications.Add($"Project Manager notified: {message}");
    }
}