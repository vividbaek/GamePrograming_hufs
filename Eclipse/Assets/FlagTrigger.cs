// FlagTrigger ����
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlagTrigger : MonoBehaviour
{
    public DoorController doorController;       // ���� ���� ��
    public string requiredPlayerTag = "LowerPlayer";

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (other.CompareTag(requiredPlayerTag))
        {
            doorController.OpenDoor();
            triggered = true;
        }
    }
}
