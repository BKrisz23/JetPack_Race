using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// First BaseFail case: sets the internal state to fail, and triggers an UnityEvent.
/// Chose UnityEvent because is exposed in the inspector.
/// </summary>
public class FailHandlerPlayer : BaseFail
{
    [SerializeField] UnityEvent OnFailedEvent;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Helper.SPIKE))
        {
            if (InternalStateEvents == null) return;

            InternalStateEvents.SetState(InternalState.Fail);
            OnFailedEvent?.Invoke();
        }
    }
}
