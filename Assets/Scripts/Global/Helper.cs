using UnityEngine;

/// <summary>
/// Global strings and helper methods for easy access 
/// </summary>
public static class Helper
{
    /// <summary>
    ///  GameObject tags
    /// </summary>
    public const string SPIKE = "Spike";
    public const string FUEL = "Fuel";
    public const string INPUT_TIME = "InputTime";

    /// <summary>
    /// Cached event names
    /// </summary>
    public const string START_RACE = "StartRaceEvent";
    public const string RESTART_RACE = "RestartRaceEvent";

    /// <summary>
    /// Cached animation names
    /// </summary>
    public const string ANIM_RUNNING = "Run";
    public const string ANIM_IDLE = "Idle";
    public const string ANIM_FLY = "Fly";
    public const string ANIM_FAIL = "Fail";
    public const string ANIM_WIN = "Win";

    /// <summary>
    /// Helper method - structural purposes
    /// </summary>
    public static void DisableGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
