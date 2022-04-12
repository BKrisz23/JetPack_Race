using UnityEngine;

/// <summary>
/// This script functions like a bridge between global events and internal states
/// I.e: When "Start Race" event is called, sets the internal state to RUN
/// </summary>
public class InternalStateHandler : MonoBehaviour
{
    [SerializeField] InternalStateEvents iStateEvents;
    public InternalStateEvents InternalStateEvents => iStateEvents;
    void OnEnable()
    {
        if (iStateEvents == null) return;
        EventManager.I.SubscribeEvent(Helper.START_RACE, setRunState);
        EventManager.I.SubscribeEvent(Helper.RESTART_RACE, setIdleState);
    }
    void OnDisable()
    {
        if (iStateEvents == null) return;
        EventManager.I.UnsubscribeEvent(Helper.START_RACE, setRunState);
        EventManager.I.UnsubscribeEvent(Helper.RESTART_RACE, setIdleState);

    }
    void setRunState()
    {
        iStateEvents.SetState(InternalState.Run);
    }
    void setIdleState()
    {
        iStateEvents.SetState(InternalState.Idle);
    }
}
