using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("컨트롤 허용 여부")]
    [Tooltip("체크된 캐릭터만 입력을 받아 이동/점프가 가능합니다.")]
    public bool canControl = false;

    [Header("이동 세팅")]
    public float moveSpeed = 15f;
    public float jumpForce = 7f;

    [Header("이동 경계 (왼쪽)")]
    [Tooltip("이 값보다 왼쪽으로는 이동하지 않습니다.")]
    public float minX = -8f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalScale = transform.localScale;

        // 땅에 닿기 전까지 이중 점프 방지
        isGrounded = false;

        // 기본 중력값 세팅 (원하는 값으로 조정 가능)
        rb.gravityScale = 2f;
    }

    void Update()
    {
        if (!canControl) return;

        // ─── 1) 수평 이동 ───────────────────────────
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // ─── 2) 왼쪽 경계(minX) 이하로 못 가게 고정 ───
        Vector3 pos = transform.position;
        pos.x = Mathf.Max(pos.x, minX);
        transform.position = pos;

        // ─── 3) 좌우 스케일 뒤집기 ──────────────────
        if (h > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (h < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // ─── 4) 점프 처리 ───────────────────────────
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // ─── 5) 애니메이션 파라미터 업데이트 ───────── (Animator가 있을 때만)
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(h));
            anim.SetBool("IsJumping", !isGrounded);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
