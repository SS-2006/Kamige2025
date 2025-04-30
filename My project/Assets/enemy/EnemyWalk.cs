using UnityEngine;

public class EnemyWalk : EnemyBase
{
    private int moveDirection = 1; // 右向き（1）または左向き（-1）

    protected override void Move()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    // 例えば、壁に当たったら方向転換とかも後で足せる
}
