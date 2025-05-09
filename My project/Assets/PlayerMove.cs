using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("接地判定")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;


    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // 横移動
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // 接地判定
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // ジャンプ
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = transform.position;

            PlayerHP pHP = GetComponent<PlayerHP>();
            if (pHP)
            {
                pHP.TakeDamage(1);
            }

            // 敵の上側に乗ったかチェック（マリオ式踏みつけ）
            //if (contactPoint.y < center.y - 0.2f)  // 足元から接触
            //{
            //    Debug.Log("敵を踏んだ！");
            //    collision.collider.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
            //    rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.8f); // 跳ね返りジャンプ
            //}
            //else
            //{
            //    // 敵の横 or 下から当たった場合 → プレイヤーがダメージ
            //    PlayerHP pHP = GetComponent<PlayerHP>();
            //    if (pHP)
            //    {
            //        pHP.TakeDamage(1);
            //    }
            //}
        }
    }
}
