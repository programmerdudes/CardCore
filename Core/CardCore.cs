using System.Diagnostics;

namespace CardCore.Core;


public class CardCore
{
    public List<Room> Rooms = new List<Room>();
    public List<Player> Players = new List<Player>();
    public int RoomIndex;
    public int PlayerIndex;
    private bool _isAlive;
    /// <summary>
    /// control a main thread
    /// T0DO: Make this better (using sleep in this case so cursed, I believe)
    /// </summary>
    public void Start()
    {
        
        
        
        _isAlive = true; // is the server alive?
        
        // stopwatch stuff
        int framecount = 0;
        Stopwatch  stopwatch = new Stopwatch();
        //
        stopwatch.Start();
        
        
        while (_isAlive) 
        {
            framecount++;
            if (stopwatch.ElapsedMilliseconds > 1000)
            {
                Console.WriteLine("Framecount: " + framecount);
                framecount = 0;
                stopwatch.Restart();
            }
            Thread.Sleep(1);
            Update();
        }
    }

    private void Update()
    {
        
    }
    
    
}

public class NewGameEvent(bool handled = false, bool cancelled = false, Room? room = null) : Event(handled, cancelled, room);