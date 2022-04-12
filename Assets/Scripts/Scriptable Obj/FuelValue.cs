using System;
using UnityEngine;

/// <summary>
/// Stores and calculates fuel value operations (adding, subtracting etc.)
/// </summary>
[CreateAssetMenu(menuName = ("Fuel/FuelValue"))]
public class FuelValue : ScriptableObject
{
    [SerializeField] float value;
    public float Value { get { return value; } private set { } }

    [SerializeField] float deltaFuel;
    public bool HasFuel => value > 0;

    Action<float> onFuelChange;

    void OnEnable()
    {
        value = 0;
    }
    public void AddFluel()
    {
        value += deltaFuel;
        onFuelChange?.Invoke(value);
    }
    public void SetZeroValue()
    {
        value = 0;
        onFuelChange?.Invoke(value);
    }
    public void ConsumeFuel()
    {
        value -= Time.deltaTime;

        if (value < 0)
            value = 0;
    }
}
