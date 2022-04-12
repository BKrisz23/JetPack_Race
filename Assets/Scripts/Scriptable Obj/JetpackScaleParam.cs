using System.Collections;
using UnityEngine;

/// <summary>
/// Holds Jetpack/Backpack scale multiplier value
/// </summary>
[CreateAssetMenu(menuName = ("JetPack/ScaleParam"))]
public class JetpackScaleParam : ScriptableObject
{
    [SerializeField] float value;
    public float Value { get { return value; } set { this.value = value; } }
}
