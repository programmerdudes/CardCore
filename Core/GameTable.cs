namespace CardCore.Core;

/// <summary>
/// so... GameTable stores players, cards, and have a system for exactly gameplay.
/// abstract carcase for game types. (battle cards, deck builder, etc.)
///
/// Id - Unique game table id (not for players or server functionality, but for developers)
/// GameName - name of game table
/// GameDescription - description of game table
/// Room - for runtime game, using room for players
/// </summary>

public abstract class GameTable
{
    public String? Id;
    public string? GameName; // this should be Locale
    public String? GameDescription; // this should be Locale
    public Room? Room; // not the best idea ig.
    
    private void Start()
    {
        EventBus.RaiseEvent(new NewGameEvent());
        Init();
    }

    private void Stop()
    {
        Shutdown();
    }

    private void TickUpdate()
    {
        Update();
    }

    protected virtual void Init() {}

    protected virtual void Shutdown() {}

    protected virtual void Update()
    {
        
    }
    
    
    
}