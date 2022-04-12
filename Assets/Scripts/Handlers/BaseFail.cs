using UnityEngine;

/// <summary>
/// Holds a refference to the internal state events
/// It's abstract because there are 2 fail cases:
/// 1. when the Player fails
/// 2. when the AI fails
/// </summary>
public abstract class BaseFail : MonoBehaviour
{
    [SerializeField] InternalStateEvents iStateEvents;
    public InternalStateEvents InternalStateEvents => iStateEvents;

}
