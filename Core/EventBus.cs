namespace CardCore.Core;

/// <summary>
/// any event we need to use in one Room (One game like card placed, card died, card... etc.)
/// any event we need to use in global server (player join, left, get achievement, etc.)
/// so, it's EventBus for one Room and Global purpose
/// 
/// Event Class
/// Handled - check if event already handled
/// Canceled - check if event  canceled
/// Room - Room (if exist)
///
/// Handler class
/// 
/// Event Priority class
///
/// </summary>
public static class EventBus
{

    private static readonly List<Handler> Handlers = new List<Handler>();
    
    /// <summary>
    /// Raise event for all handlers.
    /// </summary>
    /// <param name="e">event for raise</param>
    public static void RaiseEvent(Event e)
    {
        // sort by priority
        var sort = Handlers.OrderBy(h => h.Priority).ToList();
        foreach (var handler in sort.Where(handler => handler.Event.GetType() == e.GetType()))
        {
            handler.Handle.Invoke(e);
        }
    }
    
    public static void SubscribeHandler<TEvent>(Action<Event> handler,  TEvent e, HandlerPriority priority)  where TEvent : Event
    {
        
        Handlers.Add(new Handler(handler, e, priority));
    }
    
}

public enum HandlerPriority
{
    Sensor = 0, // lowest priority
    Low = 1,
    Medium = 2,
    High = 3,
    VeryHigh = 4, // highest priority
}

public class Event(bool handled = false, bool cancelled = false, Room? room = null)
{
    public bool Handled = handled;
    public bool Cancelled = cancelled;
    public Room? Room = room;
}

public class Handler(Action<Event> handler, Event e, HandlerPriority priority)
{
    public Event Event { get; } = e;
    public HandlerPriority Priority { get; set; } = priority;
    public Action<Event> Handle { get; set; } = handler;
}