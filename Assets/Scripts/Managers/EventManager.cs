using System;

/// <summary>
/// Holds global events like "Start Race" and "Restart Race"
/// </summary>
public class EventManager
{
    static EventManager instance;
    public static EventManager I
    {
        get
        {
            if (instance == null)
                instance = new EventManager();

            return instance;
        }
        private set { }
    }

    Action onStartRace;
    Action onRestartRace;

    public void TriggerEvent(string eventName)
    {
        switch (eventName)
        {
            case Helper.START_RACE: onStartRace?.Invoke(); break;
            case Helper.RESTART_RACE: onRestartRace?.Invoke(); break;
        }
    }
    public void SubscribeEvent(string eventName, Action action)
    {
        switch (eventName)
        {
            case Helper.START_RACE: onStartRace += action; break;
            case Helper.RESTART_RACE: onRestartRace += action; break;
        }
    }
    public void UnsubscribeEvent(string eventName, Action action)
    {
        switch (eventName)
        {
            case Helper.START_RACE: onStartRace -= action; break;
            case Helper.RESTART_RACE: onRestartRace -= action; break;
        }
    }
}