using UnityEngine;

public class EnemyWalk : EnemyBase
{
    [Header("歩き敵用設定")]
    public LayerMask groundLayer;
    public Transform groundCheckDown;
    public Transform wallCheckFront; // ← 壁チェック用
    public float groundCheckDistance = 0.3f;
    public float wallCheckDistance = 0.3f; // ← 壁との距離

    private int moveDirection = 1;

    protected override void Move()
    {
        // 移動
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);

        // 崖または壁を検出したら向きを反転
        if (!IsGroundBelow() || IsWallAhead())
        {
            FlipDirection();
        }
    }

    private bool IsGroundBelow()
    {
        if (groundCheckDown == null) return true;

        RaycastHit2D hit = Physics2D.Raycast(groundCheckDown.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    private bool IsWallAhead()
    {
        if (wallCheckFront == null) return false;

        Vector2 direction = new Vector2(moveDirection, 0);
        RaycastHit2D hit = Physics2D.Raycast(wallCheckFront.position, direction, wallCheckDistance, groundLayer);
        return hit.collider != null;
    }

    private void FlipDirection()
    {
        moveDirection *= -1;
        Flip(moveDirection);
    }
}
