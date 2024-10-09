namespace BuildingProject.Logger;

public interface ILogger
{
    int MessageCount { get; }
    string GetLogMessages();
    void Log(string message);
    void WriteLogToFile(string filename);
}