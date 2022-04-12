using System.Collections;
using UnityEngine;

/// <summary>
/// Detects input colliders and injects random input time - copying human behaviour
/// </summary>
public class InputHandlerAI : MonoBehaviour, IInputHandler
{
    public bool IsTouch { get; private set; }

    [SerializeField] float inputTime;

    IInputTime iInputTime;

    void Update()
    {
        if (inputTime <= 0)
            return;

        IsTouch = true;
        inputTime -= Time.deltaTime;

        if (inputTime <= 0)
            IsTouch = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Helper.INPUT_TIME))
        {
            iInputTime = other.GetComponent<IInputTime>();
            if (iInputTime == null)
                return;

            inputTime = iInputTime.GetInputTime();
            iInputTime = null;
        }
    }
}
