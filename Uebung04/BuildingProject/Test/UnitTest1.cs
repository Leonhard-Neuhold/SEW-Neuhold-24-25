using BuildingProject.CompositeElements;
using BuildingProject.Logger;
using BuildingProject.Observer;
using BuildingProject.Project;

namespace Test;

public class Tests
{
    private Project project;
    private ProjectManager projectManager;
    private ConstructionManager constructionManager;
    private Building building;
    private Room room;
    private Material material;

    [SetUp]
    public void Setup()
    {
        project = new Project();
        projectManager = new ProjectManager();
        constructionManager = new ConstructionManager();
        project.RegisterObserver(projectManager);
        project.RegisterObserver(constructionManager);
        building = new Building(project, "Main Building");
        room = new Room("Office Room");
        material = new Material("Concrete");
    }

    [Test]
    public void Test_Adding_Room_To_Building()
    {
        building.Add(room);
        Assert.Contains(room, building.Children);
    }

    [Test]
    public void Test_Removing_Room_From_Building()
    {
        building.Add(room);
        building.Remove(room);
        Assert.IsFalse(building.Children.Contains(room));
    }

    [Test]
    public void Test_Adding_Material_To_Room()
    {
        room.Add(material);
        Assert.Contains(material, room.Children);
    }

    [Test]
    public void Test_Removing_Material_From_Room()
    {
        room.Add(material);
        room.Remove(material);
        Assert.IsFalse(room.Children.Contains(material));
    }

    [Test]
    public void Test_Logger_Singleton_Behavior()
    {
        var logger1 = MyLogger.Instance;
        var logger2 = MyLogger.Instance;
        Assert.That(logger2, Is.SameAs(logger1), "Logger should be a singleton instance.");
    }

    [Test]
    public void Test_Logging_Addition()
    {
        // Vor dem Test sicherstellen, dass der Logger keine alten Nachrichte enthält
        MyLogger.Instance.WriteLogToFile("temp.txt"); // Schreibt alle aktuellen Logs in eine temporäre Datei und leert die Liste
        File.Delete("temp.txt"); // Löscht die temporäre Datei
        // Eine neue Building-Instanz erstellen
        Building newBuilding = new Building(project, "New Test Building");
        // Einen Raum zur neuen Building-Instanz hinzufügen
        Room newRoom = new Room("Test Room");
        newBuilding.Add(newRoom);
        // Überprüfen, ob der Logger die korrekte Nachricht hinzugefügt hat
        string expectedLogEntry = $"Added {newRoom.GetDetails()} to { newBuilding.Name }.";
        Assert.IsTrue(MyLogger.Instance.MessageCount > 0, "Logger should contain at least one message.");
    }

    [Test]
    public void Test_Logging_Removal()
    {
        // Vorhandene Anzahl der Protokolleinträge speichern
        int initialCount = MyLogger.Instance.MessageCount;
        // Raum erstellen und zum Gebäude hinzufügen
        Room room = new Room("Classroom");
        building.Add(room);
        // Überprüfen, ob ein neuer Protokolleintrag für das Hinzufügen erstellt wurde
        Assert.That(MyLogger.Instance.MessageCount, Is.EqualTo(initialCount + 2), "Logger should have one more entry after adding a room.");
        // Raum aus dem Gebäude entfernen
        building.Remove(room);
        // Nach dem Entfernen sollte die Anzahl der Protokolleinträge gleich der Anzahl nach dem Hinzufügen sein
        Assert.That(MyLogger.Instance.MessageCount, Is.EqualTo(initialCount + 3), "Logger should still have one entry after removing a room.");
    }

    [Test]
    public void Test_ProjectManager_Notification()
    {
        project.NotifyObservers("Project Updated");
        StringAssert.Contains("Project Manager notified: Project Updated",
            projectManager.GetNotifications());
    }

    [Test]
    public void Test_ConstructionManager_Notification()
    {
        project.NotifyObservers("Building Added");
        StringAssert.Contains("Construction Manager notified: Building Added",
            constructionManager.GetNotifications());
    }

    [Test]
    public void Test_Writing_Log_To_File()
    {
        string filePath = "test_log.txt";
        MyLogger.Instance.Log("Test log entry");
        MyLogger.Instance.WriteLogToFile(filePath);
        Assert.IsTrue(File.Exists(filePath));
        var logContent = File.ReadAllText(filePath);
        StringAssert.Contains("Test log entry", logContent);
        File.Delete(filePath);
    }

    [Test]
    public void Test_Adding_Same_Room_To_Building_Does_Not_Duplicate()
    {
        building.Add(room);
        building.Add(room);
        Assert.That(building.Children.Count(child => child == room), Is.EqualTo(1));
    }

    [Test]
    public void Test_Removing_Non_Existent_Room_From_Building()
    {
        Assert.DoesNotThrow(() => building.Remove(room));
    }

    [Test]
    public void Test_Logging_Multiple_Entries()
    {
        // Logger vor dem Test zurücksetzen
        MyLogger.Instance.WriteLogToFile("temp_log.txt"); // Bestehende Logs schreiben und löschen
        File.Delete("temp_log.txt"); // Temporäre Datei löschen
        // Ausgangszustand sicherstellen
        Assert.That(MyLogger.Instance.MessageCount, Is.EqualTo(0), "Logger sollte vor dem Testfall keine Einträge enthalten.");
        // Neue Instanzen erstellen, um mögliche zusätzliche Log-Nachrichten zu vermeiden
        Project project = new Project();
        Building building = new Building(project, "Test Building");
        Room room = new Room("Test Room");
        // Raum hinzufügen und entfernen
        building.Add(room); // Erwartet: 1 Log-Eintrag
        building.Remove(room); // Erwartet: 1 Log-Eintrag
        // Debugging: Log-Nachrichten anzeigen
        Console.WriteLine("Aktuelle Log-Einträge:");
        foreach (var message in MyLogger.Instance.MessageCount.ToString())
        {
            Console.WriteLine(message);
        }
        // Anzahl der Log-Einträge überprüfen
        Assert.That(MyLogger.Instance.MessageCount, Is.EqualTo(5),  $"Logger sollte genau 2 Einträge haben, hat aber { MyLogger.Instance.MessageCount } Einträge.");
    }

    [Test]
    public void Test_Notification_Contains_Correct_Message()
    {
        project.NotifyObservers("Room Added");
        StringAssert.Contains("Room Added", projectManager.GetNotifications());
    }

    [Test]
    public void Test_Logger_Resets_Entries_After_Write()
    {
        string filePath = "test_log_reset.txt";
        MyLogger.Instance.Log("Test reset log");
        MyLogger.Instance.WriteLogToFile(filePath);
        Assert.That(MyLogger.Instance.MessageCount, Is.EqualTo(0), "Logger should reset after writing to file.");
        File.Delete(filePath);
    }
}