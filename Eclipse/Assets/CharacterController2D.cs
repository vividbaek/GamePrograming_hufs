using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("컨트롤 허용 여부")]
    [Tooltip("체크된 캐릭터만 입력을 받아 이동/점프가 가능합니다.")]
    public bool canControl = false;

    [Header("이동 세팅")]
    public float moveSpeed = 15f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalScale = transform.localScale;
        isGrounded = false;
        rb.gravityScale = 2f;
    }

    void Update()
    {
        // 컨트롤 플래그가 꺼져 있으면 아무 동작도 하지 않음
        if (!canControl) return;

        // 1) 수평 이동
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 2) 좌우 방향으로 스케일 뒤집기
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // 4) 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            // 땅에 닿을 때만 중력을 켜 줌
            rb.gravityScale = 2f;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
