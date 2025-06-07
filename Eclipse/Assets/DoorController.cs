using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class DoorController : MonoBehaviour
{
    [Header("문 스프라이트")]
    public Sprite closedSprite;   // 닫힌 문 이미지
    public Sprite openSprite;     // 열린 문 이미지

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        // 시작 시 닫힌 상태
        sr.sprite = closedSprite;
        col.isTrigger = false;
    }

    /// <summary>
    /// 문을 연 상태로 바꿉니다.
    /// </summary>
    public void OpenDoor()
    {
        sr.sprite = openSprite;
        col.isTrigger = true;
    }
}
