using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class DoorController : MonoBehaviour
{
    [Header("�� ��������Ʈ")]
    public Sprite closedSprite;   // ���� �� �̹���
    public Sprite openSprite;     // ���� �� �̹���

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        // ���� �� ���� ����
        sr.sprite = closedSprite;
        col.isTrigger = false;
    }

    /// <summary>
    /// ���� �� ���·� �ٲߴϴ�.
    /// </summary>
    public void OpenDoor()
    {
        sr.sprite = openSprite;
        col.isTrigger = true;
    }
}
