using UnityEngine;

public class FlagDoorInteraction : MonoBehaviour
{
    public GameObject doorTilemap; // 문 Tilemap
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
        doorTilemap.SetActive(false); // 문 비활성화 (열림)
    }

    void CloseDoor()
    {
        doorTilemap.SetActive(true); // 문 활성화 (닫힘)
    }
}