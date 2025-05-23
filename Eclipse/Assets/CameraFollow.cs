using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("따라갈 대상 Transform")]
    public Transform target;
    [Tooltip("카메라와 대상 간의 상대 오프셋")]
    public Vector3 offset = new Vector3(0, 1, -10);
    [Tooltip("부드럽게 따라올 때 보간 속도")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);
        transform.position = smoothed;
    }
}
