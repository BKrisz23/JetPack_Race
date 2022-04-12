using UnityEngine;

/// <summary>
/// Sets global gravity
/// </summary>
public class GravityHandler : MonoBehaviour
{
    [SerializeField] Vector3 gravity;

    void Awake()
    {
        Physics.gravity = gravity;
    }
}
