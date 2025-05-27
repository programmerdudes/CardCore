namespace CardCore.Core;

public class Room
{
    public int Id;
    public bool IsGameActive = false;
    public List<Player> Players = [];
    public DateTime? StartTime;
    
    public string Name;
    public string? Description;
    public string? Password;

    public Room(int id, string name, string? description = null, string? password = null)
    {
        Id = id;
        Name = name;
        Description = description;
        Password = password;
    }
    
}