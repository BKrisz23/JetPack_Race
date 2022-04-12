using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls an UnityEvent when Player won
/// I.e Enable Win Canvas
/// Chose UnityEvents because it's editor friendly
/// </summary>
public class PlayerWinHandler : MonoBehaviour
{
    [SerializeField] InternalStateEvents iStateEvents;
    [SerializeField] UnityEvent onWinEvent;

    void OnEnable()
    {
        iStateEvents.SubscribeEvent(InternalState.Win, triggerWin);
    }
    void OnDisable()
    {
        iStateEvents.UnsubscribeEvent(InternalState.Win, triggerWin);
    }
    void triggerWin()
    {
        onWinEvent?.Invoke();
    }
}
