using UnityEngine;

public class EnemyChaser : EnemyBase
{
    [Header("追跡設定")]
    public float detectRange = 5f;

    protected override void Move()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            // プレイヤーに向かって移動
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            Flip(direction);
        }
        else
        {
            // プレイヤーが範囲外なら停止
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
