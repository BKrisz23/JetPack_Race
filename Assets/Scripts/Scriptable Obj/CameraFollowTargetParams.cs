using System.Collections;
using UnityEngine;

/// <summary>
/// Hold camera data like Offset position and follow speed
/// </summary>
[CreateAssetMenu(menuName = ("Camera/Follow Target Params"))]
public class CameraFollowTargetParams : ScriptableObject
{
    [SerializeField] Vector3 offsetPosition;
    public Vector3 OffsetPosition => offsetPosition;

    [SerializeField] Vector3 followSpeed;
    public Vector3 FollowSpeed => followSpeed;
}
