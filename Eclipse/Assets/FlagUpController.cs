using UnityEngine;

public class FlagUpController : MonoBehaviour
{
    [Header("��� ����� �� ������Ʈ")]
    public GameObject whiteWall;  // Hierarchy���� white wall ������Ʈ �Ҵ�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // whiteWall GameObject ��ü�� ���� ������ �ʰ� �մϴ�.
            whiteWall.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ʈ���� ������ ����� �ٽ� Ȱ��ȭ
            whiteWall.SetActive(true);
        }
    }
}
