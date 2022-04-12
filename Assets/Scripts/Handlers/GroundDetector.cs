using UnityEngine;

/// <summary>
/// Checks if the entry is on the ground and calls an event accordingly
/// </summary>
public class GroundDetector : MonoBehaviour
{
    [SerializeField] InternalStateEvents iStateEvents;
    [SerializeField] bool isRacing;
    [SerializeField] bool isOnGround;
    [SerializeField] Transform startingPosTransform;
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;

    Collider[] results = new Collider[1];

    void OnEnable()
    {
        EventManager.I.SubscribeEvent(Helper.START_RACE, startRacing);

        if (iStateEvents == null) return;
        iStateEvents.SubscribeEvent(InternalState.Fail, stopRacing);
        iStateEvents.SubscribeEvent(InternalState.Idle, stopRacing);
        iStateEvents.SubscribeEvent(InternalState.Win, stopRacing);
    }
    void OnDisable()
    {
        EventManager.I.UnsubscribeEvent(Helper.START_RACE, startRacing);

        if (iStateEvents == null) return;

        iStateEvents.UnsubscribeEvent(InternalState.Fail, stopRacing);
        iStateEvents.UnsubscribeEvent(InternalState.Idle, stopRacing);
        iStateEvents.UnsubscribeEvent(InternalState.Win, stopRacing);
    }
    void FixedUpdate()
    {
        if (!isRacing) return;

        Vector3 destinationPos = new Vector3(startingPosTransform.position.x, startingPosTransform.position.y * radius, startingPosTransform.position.z);

        isOnGround = Physics.OverlapSphereNonAlloc(startingPosTransform.position, radius, results, layerMask) > 0;

        if (isOnGround)
            iStateEvents.SetState(InternalState.Run);
        else
            iStateEvents.SetState(InternalState.Fly);

    }
    void startRacing()
    {
        isRacing = true;
    }
    void stopRacing()
    {
        isRacing = false;
    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(startingPosTransform.position, radius);
    }
#endif
}
