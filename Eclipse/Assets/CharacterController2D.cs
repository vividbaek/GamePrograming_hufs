using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("��Ʈ�� ��� ����")]
    [Tooltip("üũ�� ĳ���͸� �Է��� �޾� �̵�/������ �����մϴ�.")]
    public bool canControl = false;

    [Header("�̵� ����")]
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
        // ��Ʈ�� �÷��װ� ���� ������ �ƹ� ���۵� ���� ����
        if (!canControl) return;

        // 1) ���� �̵�
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 2) �¿� �������� ������ ������
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        // 4) ���� ó��
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
            // ���� ���� ���� �߷��� �� ��
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
