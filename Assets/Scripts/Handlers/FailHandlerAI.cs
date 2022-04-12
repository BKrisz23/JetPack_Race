using UnityEngine;

/// <summary>
/// Second BaseFail case: sets the internal state to fail
/// </summary>
public class FailHandlerAI : BaseFail
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Helper.SPIKE))
        {
            if (InternalStateEvents == null) return;
            InternalStateEvents.SetState(InternalState.Fail);
        }
    }
}
