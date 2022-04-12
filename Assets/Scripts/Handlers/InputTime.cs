using UnityEngine;
/// <summary>
/// Holds min and max values and returns a random input time for AI
/// </summary>
public class InputTime : MonoBehaviour, IInputTime
{
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    public float GetInputTime()
    {
        return UnityEngine.Random.Range(minTime, maxTime);
    }

}
