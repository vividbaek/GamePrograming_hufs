using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("���� ��� Transform")]
    public Transform target;
    [Tooltip("ī�޶�� ��� ���� ��� ������")]
    public Vector3 offset = new Vector3(0, 1, -10);
    [Tooltip("�ε巴�� ����� �� ���� �ӵ�")]
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * smoothSpeed);
        transform.position = smoothed;
    }
}
