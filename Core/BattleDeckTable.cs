namespace CardCore.Core;

public sealed class BattleDeckTable : GameTable
{
    public BattleDeckTable()
    {
        Init();
        Id =  "BattleDeckTable";
        GameName = "Battle Deck Table";
        GameDescription = "Battle Deck Table";
    }

    protected override void Init()
    {
        base.Init();
        
        EventBus.RaiseEvent(new NewGameEvent());
    }
}