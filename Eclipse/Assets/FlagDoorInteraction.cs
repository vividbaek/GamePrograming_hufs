using UnityEngine;

public class FlagDoorInteraction : MonoBehaviour
{
    public GameObject doorTilemap; // �� Tilemap
    private bool isFlagActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Flag"))
        {
            isFlagActivated = true;
            Debug.Log("Flag activated!");
            OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Flag"))
        {
            isFlagActivated = false;
            Debug.Log("Flag deactivated!");
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        doorTilemap.SetActive(false); // �� ��Ȱ��ȭ (����)
    }

    void CloseDoor()
    {
        doorTilemap.SetActive(true); // �� Ȱ��ȭ (����)
    }
}