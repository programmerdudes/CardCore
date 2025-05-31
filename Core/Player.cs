namespace CardCore.Core;

/// <summary>
///  need to refactor later, I don't want to overcomplicate things at this stage (because i don't know rn how i wanna
/// implement registration (are we need registration?...)
/// </summary>
public class Player
{
    public int Id; // currently on runtime, not in database or whatever we gonna save game data
    public string Username;
    public Status Status;

    public Player(string username)
    {
        Username = username;
        Id = 0;
        Status = Status.InLobby;
    }


    public void CreatePlayer()
    {
        // code
    }

    public  void DeletePlayer()
    {
        // code
    }
    
}

public enum Status
{
    InLobby = 0,
    InGame = 1,
    Offline = 2
}