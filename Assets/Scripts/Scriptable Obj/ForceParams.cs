using System.Collections;
using UnityEngine;

/// <summary>
/// Holds force data like "run force",
/// rigidbody clamp values etc.
/// </summary>
[CreateAssetMenu(menuName = ("Force/Params"))]
public class ForceParams : ScriptableObject
{
    [SerializeField] float runForce;
    [Space]
    [SerializeField] float yForce;
    [Space]
    [SerializeField] float minVelY;
    [SerializeField] float maxVelY;
    public float RunForce => runForce;
    public float YForce => yForce;
    public float MinVelY => minVelY;
    public float MaxVelY => maxVelY;
}
