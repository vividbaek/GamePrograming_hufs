using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Header("��Ʈ�� ��� ����")]
    [Tooltip("üũ�� ĳ���͸� �Է��� �޾� �̵�/������ �����մϴ�.")]
    public bool canControl = false;

    [Header("�̵� ����")]
    public float moveSpeed = 15f;
    public float jumpForce = 7f;

    [Header("�̵� ��� (����)")]
    [Tooltip("�� ������ �������δ� �̵����� �ʽ��ϴ�.")]
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

        // ���� ��� ������ ���� ���� ����
        isGrounded = false;

        // �⺻ �߷°� ���� (���ϴ� ������ ���� ����)
        rb.gravityScale = 2f;
    }

    void Update()
    {
        if (!canControl) return;

        // ������ 1) ���� �̵� ������������������������������������������������������
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        // ������ 2) ���� ���(minX) ���Ϸ� �� ���� ���� ������
        Vector3 pos = transform.position;
        pos.x = Mathf.Max(pos.x, minX);
        transform.position = pos;

        // ������ 3) �¿� ������ ������ ������������������������������������
        if (h > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (h < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        // ������ 4) ���� ó�� ������������������������������������������������������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // ������ 5) �ִϸ��̼� �Ķ���� ������Ʈ ������������������ (Animator�� ���� ����)
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
