using UnityEngine;

/// <summary>
/// Handles RigidBody operations for a race entry
/// </summary>
public class ForceHandler : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] FuelValue fuel;
    [SerializeField] ForceParams fParams;
    [SerializeField] InternalStateEvents iStateEvents;

    bool isRunning;

    IInputHandler inputHandler;

    Vector3 currentForce;

    void OnEnable()
    {
        if (iStateEvents == null) return;
        iStateEvents.SubscribeEvent(InternalState.Run, startRun);
        iStateEvents.SubscribeEvent(InternalState.Fail, stopRun);
        iStateEvents.SubscribeEvent(InternalState.Idle, stopRun);
        iStateEvents.SubscribeEvent(InternalState.Win, stopRun);
    }
    void OnDisable()
    {
        if (iStateEvents == null) return;
        iStateEvents.UnsubscribeEvent(InternalState.Run, startRun);
        iStateEvents.UnsubscribeEvent(InternalState.Fail, stopRun);
        iStateEvents.UnsubscribeEvent(InternalState.Idle, stopRun);
        iStateEvents.UnsubscribeEvent(InternalState.Win, stopRun);
    }
    void Start()
    {
        inputHandler = GetComponent<IInputHandler>();
    }
    void FixedUpdate()
    {
        currentForce = rb.velocity;

        if (inputHandler != null && inputHandler.IsTouch && fuel != null && fuel.HasFuel && fParams != null)
        {
            if (rb.velocity.y < 0)
            {
                currentForce.y = currentForce.y / 2f;
            }

            rb.AddForce(Vector3.up * fParams.YForce, ForceMode.Acceleration);
        }

        if (fParams != null && isRunning)
        {
            currentForce.z = fParams.RunForce * Time.deltaTime;
        }

        currentForce.y = Mathf.Clamp(currentForce.y, fParams.MinVelY, fParams.MaxVelY);
        rb.velocity = currentForce;
    }
    void startRun()
    {
        if (fParams == null) return;

        isRunning = true;
    }
    void stopRun()
    {
        if (fParams == null) return;

        isRunning = false;
        rb.velocity = Vector3.zero;
        currentForce = Vector3.zero;
    }
}
