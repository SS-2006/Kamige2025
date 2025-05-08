using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("�ړ��ݒ�")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("�ڒn����")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [Header("�v���C���[HP")]
    public int hp = 3;
    public float invincibleTime = 1.0f;
    private float invincibleTimer = 0f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���G���ԃJ�E���g
        if (invincibleTimer > 0f)
        {
            invincibleTimer -= Time.deltaTime;
        }

        // ���ړ�
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // �ڒn����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // �W�����v
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// �_���[�W�����i���G���Ԃ���j
    /// </summary>
    public void TakeDamage(int damage)
    {
        if (invincibleTimer > 0f) return;

        hp -= damage;
        invincibleTimer = invincibleTime;

        Debug.Log($"Player took {damage} damage. HP now: {hp}");

        if (hp <= 0)
        {
            Debug.Log("�v���C���[���S�I");
            // ���S�����Ȃǂ͂����ɒǉ�
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = transform.position;

            // �G�̏㑤�ɏ�������`�F�b�N�i�}���I�����݂��j
            if (contactPoint.y < center.y - 0.2f)  // ��������ڐG
            {
                Debug.Log("�G�𓥂񂾁I");
                collision.collider.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f); // ���˕Ԃ�W�����v
            }
            else
            {
                // �G�̉� or �����瓖�������ꍇ �� �v���C���[���_���[�W
                TakeDamage(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
