using System.Collections;
using UnityEngine;

/// <summary>
/// Waiting for the "Start Race Input" then calls an event accordingly
/// </summary>
public class RaceHandler : MonoBehaviour
{
    [SerializeField] bool isRaceStarted;

    void OnEnable()
    {
        EventManager.I.SubscribeEvent(Helper.RESTART_RACE, readInput);
    }
    void OnDisable()
    {
        EventManager.I.UnsubscribeEvent(Helper.RESTART_RACE, readInput);
    }
    void Start()
    {
        readInput();
    }
    void readInput()
    {
        StartCoroutine(raceInputReaderCo());
    }
    IEnumerator raceInputReaderCo()
    {
        isRaceStarted = false;

        while (Input.touchCount > 0)
            yield return null;

        while (!isRaceStarted)
        {
            if (Input.touchCount > 0) isRaceStarted = true;
            yield return null;
        }

        EventManager.I.TriggerEvent(Helper.START_RACE);
    }
}
