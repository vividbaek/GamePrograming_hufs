using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlagTrigger : MonoBehaviour
{
    [Header("������ �� ��Ʈ�ѷ�")]
    public DoorController door;   // Inspector���� �Ҵ�

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // �Ʒ� �÷��̾ ��߿� ����� ��
        if (!triggered && other.CompareTag("LowerPlayer"))
        {
            door.OpenDoor();   // �� ����
            triggered = true;  // �� ���� ����
        }
    }
}
