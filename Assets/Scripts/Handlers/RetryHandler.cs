using System.Collections;
using UnityEngine;

/// <summary>
/// Resets the gameloop
/// Waiting for the "Retry Input" then calls an event accordingly
/// Functions only on win and fail states
/// </summary>
public class RetryHandler : MonoBehaviour
{
    [SerializeField] GameObject root;

    void OnEnable()
    {
        StartCoroutine(readInputCo());
    }
    IEnumerator readInputCo()
    {
        while (Input.touchCount > 0)
            yield return null;

        while (Input.touchCount <= 0)
            yield return null;

        root.SetActive(false);
        EventManager.I.TriggerEvent(Helper.RESTART_RACE);
    }
}
