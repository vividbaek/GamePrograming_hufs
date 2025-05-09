using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlagTrigger : MonoBehaviour
{
    [Header("열어줄 문 컨트롤러")]
    public DoorController door;   // Inspector에서 할당

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // 아래 플레이어가 깃발에 닿았을 때
        if (!triggered && other.CompareTag("LowerPlayer"))
        {
            door.OpenDoor();   // 문 열기
            triggered = true;  // 한 번만 실행
        }
    }
}
