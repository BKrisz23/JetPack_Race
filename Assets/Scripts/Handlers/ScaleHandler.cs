using UnityEngine;

/// <summary>
/// Handles the backpack/jetpack fuel size on the back of the race entry
/// </summary>
public class ScaleHandler : MonoBehaviour
{
    [SerializeField] FuelValue fuel;
    [SerializeField] Transform transformToScale;
    [Space]
    [SerializeField] JetpackScaleParam scaleFactor;

    float previousFuelValue;
    Vector3 currentScale;

    void Start()
    {
        if (fuel == null || scaleFactor == null) return;
        setScale();
    }
    void Update()
    {
        if (fuel == null || scaleFactor == null) return;

        if (previousFuelValue != fuel.Value)
            setScale();

        previousFuelValue = fuel.Value;
    }
    void setScale()
    {
        currentScale = transformToScale.localScale;
        currentScale.y = fuel.Value * scaleFactor.Value;
        transformToScale.localScale = currentScale;
    }
}
