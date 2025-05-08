using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("이동 세팅")]
    public float moveSpeed = 3f;
    public float jumpForce = 2f;

    private Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        // Animator가 없으면 null
        originalScale = transform.localScale;
        isGrounded = true;
        rb.gravityScale = 0f;                   // 초기 중력 비활성화
    }

    void Update()
    {
        // 1) 이동 처리
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 2) 방향 전환
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // 3) 애니메이션 파라미터 (Animator가 있을 때만)
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput));
            anim.SetBool("IsJumping", !isGrounded);
        }

        // 4) 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground 태그만 검사하도록 변경
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.gravityScale = 2f;               // 중력 활성화
            Debug.Log("Collided with: " + collision.gameObject.name);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
