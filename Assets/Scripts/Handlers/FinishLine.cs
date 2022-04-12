using UnityEngine;

/// <summary>
/// Checks if an entry crossed the line and sets its internal state to win
/// </summary>
public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        InternalStateHandler iStateHandler = other.GetComponent<InternalStateHandler>();

        if (iStateHandler == null) return;

        iStateHandler.InternalStateEvents.SetState(InternalState.Win);
    }
}
