using UnityEngine;

/// <summary>
/// Handles fuel operations. I.e. adding, subtracting
/// </summary>
public class FuelHandler : MonoBehaviour
{
    [SerializeField] FuelValue fuel;
    [SerializeField] InternalStateEvents iStateEvents;

    IInputHandler inputHandler;

    void OnEnable()
    {

        if (iStateEvents == null || fuel == null) return;

        iStateEvents.SubscribeEvent(InternalState.Fail, fuel.SetZeroValue);
        iStateEvents.SubscribeEvent(InternalState.Win, fuel.SetZeroValue);

        EventManager.I.SubscribeEvent(Helper.RESTART_RACE, fuel.SetZeroValue);
    }
    void OnDisable()
    {
        if (iStateEvents == null || fuel == null) return;

        iStateEvents.UnsubscribeEvent(InternalState.Fail, fuel.SetZeroValue);
        iStateEvents.UnsubscribeEvent(InternalState.Win, fuel.SetZeroValue);

        EventManager.I.UnsubscribeEvent(Helper.RESTART_RACE, fuel.SetZeroValue);
    }
    void Start()
    {
        inputHandler = GetComponent<IInputHandler>();
    }
    void Update()
    {
        if (inputHandler == null || fuel == null)
            return;

        if (inputHandler.IsTouch)
        {
            fuel.ConsumeFuel();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (fuel == null) return;

        if (other.CompareTag(Helper.FUEL))
        {
            fuel.AddFluel();
            Helper.DisableGameObject(other.gameObject);
        }

    }
}
