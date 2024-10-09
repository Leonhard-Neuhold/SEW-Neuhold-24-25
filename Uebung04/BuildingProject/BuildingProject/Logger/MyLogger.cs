namespace BuildingProject.Logger;

public class MyLogger : ILogger
{
    private List<string> logMessages;
    private static MyLogger instance;

    public int MessageCount => logMessages.Count;

    public static MyLogger Instance
    {
        get
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;
        }
    }

    private MyLogger()
    {
        logMessages = new List<string>();   
    }
    
    public string GetLogMessages()
    {
        return string
            .Join("\n", logMessages);
    }
    public void Log(string message)
    {
        logMessages.Add(message);
    }
    public void WriteLogToFile(string filename)
    {
        File.WriteAllLines(filename, logMessages);
        logMessages.Clear();
    }
}