using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // ���� ĳ����
    public float smoothSpeed = 5f; // ���� �ӵ�
    public Vector3 offset;         // (��: X=0, Y=1, Z=-10)

    private float minX;            // ���� �Ѱ輱

    void Start()
    {
        // ���� ���� �� ī�޶��� �ʱ� X ��ǥ�� ���� �Ѱ�� ��´�
        minX = transform.position.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1) ��ǥ X ��ġ ���
        float desiredX = target.position.x + offset.x;
        // 2) ���� �Ѱ輱(minX) ���� �۾����� �ʵ��� Ŭ����
        desiredX = Mathf.Max(minX, desiredX);

        // 3) Y, Z �� �״��
        Vector3 desiredPos = new Vector3(
            desiredX,
            transform.position.y,
            transform.position.z
        );

        // 4) �ε巴�� ����
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            Time.deltaTime * smoothSpeed
        );
    }
}
