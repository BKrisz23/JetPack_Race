using UnityEngine;
public class CamFollowTarget : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform cameraTransform;

    [SerializeField] CameraFollowTargetParams cParams;
    void Start()
    {
        if (targetTransform == null || cameraTransform == null || cParams == null) return;

        cameraTransform.position = targetTransform.position + cParams.OffsetPosition;
    }

    void LateUpdate()
    {
        if (targetTransform == null || cameraTransform == null || cParams == null) return;

        Vector3 nextPos;

        nextPos.x = Mathf.Lerp(cameraTransform.position.x, targetTransform.position.x + cParams.OffsetPosition.x, cParams.FollowSpeed.x * Time.deltaTime);
        nextPos.y = Mathf.Lerp(cameraTransform.position.y, targetTransform.position.y + cParams.OffsetPosition.y, cParams.FollowSpeed.y * Time.deltaTime);
        nextPos.z = Mathf.Lerp(cameraTransform.position.z, targetTransform.position.z + cParams.OffsetPosition.z, cParams.FollowSpeed.z * Time.deltaTime);

        cameraTransform.position = nextPos;
    }


}
