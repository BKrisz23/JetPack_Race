using UnityEngine;

/// <summary>
/// Holds a refference for each race entry, 
/// caches the starting position and
/// resets position on action call
/// </summary>
public class StartPositionHandler : MonoBehaviour
{
    [SerializeField] Vector3 startingPos;

    [SerializeField] Transform[] raceEntries;

    void OnEnable()
    {
        EventManager.I.SubscribeEvent(Helper.RESTART_RACE, resetPosition);
    }
    void OnDisable()
    {
        EventManager.I.UnsubscribeEvent(Helper.RESTART_RACE, resetPosition);
    }
    void Start()
    {
        if (raceEntries.Length > 0)
            startingPos = raceEntries[0].position;

        startingPos.x = 0;
    }
    void resetPosition()
    {
        Vector3 currentPos;
        for (int i = 0; i < raceEntries.Length; i++)
        {
            currentPos = raceEntries[i].position;
            currentPos.z = startingPos.z;
            currentPos.y = startingPos.y;
            raceEntries[i].position = currentPos;
        }
    }
}
