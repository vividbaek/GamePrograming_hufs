using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("�̵� ����")]
    public float moveSpeed = 3f;
    public float jumpForce = 2f;

    private Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        // Animator�� ������ null
        originalScale = transform.localScale;
        isGrounded = true;
        rb.gravityScale = 0f;                   // �ʱ� �߷� ��Ȱ��ȭ
    }

    void Update()
    {
        // 1) �̵� ó��
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 2) ���� ��ȯ
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // 3) �ִϸ��̼� �Ķ���� (Animator�� ���� ����)
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput));
            anim.SetBool("IsJumping", !isGrounded);
        }

        // 4) ���� ó��
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground �±׸� �˻��ϵ��� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.gravityScale = 2f;               // �߷� Ȱ��ȭ
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
