using UnityEngine;

/// <summary>
/// Checks if there is Player input
/// </summary>
public class InputHandler : MonoBehaviour, IInputHandler
{
    public bool IsTouch { get; private set; }

    void Update()
    {
        IsTouch = Input.touchCount > 0;
    }
}
