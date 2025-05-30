using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // 따라갈 캐릭터
    public float smoothSpeed = 5f; // 보간 속도
    public Vector3 offset;         // (예: X=0, Y=1, Z=-10)

    private float minX;            // 왼쪽 한계선

    void Start()
    {
        // 게임 시작 시 카메라의 초기 X 좌표를 왼쪽 한계로 삼는다
        minX = transform.position.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1) 목표 X 위치 계산
        float desiredX = target.position.x + offset.x;
        // 2) 왼쪽 한계선(minX) 보다 작아지지 않도록 클램프
        desiredX = Mathf.Max(minX, desiredX);

        // 3) Y, Z 는 그대로
        Vector3 desiredPos = new Vector3(
            desiredX,
            transform.position.y,
            transform.position.z
        );

        // 4) 부드럽게 보간
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            Time.deltaTime * smoothSpeed
        );
    }
}
