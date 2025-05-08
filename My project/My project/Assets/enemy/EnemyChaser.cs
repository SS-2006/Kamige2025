using UnityEngine;

public class EnemyChaser : EnemyBase
{
    [Header("�ǐՐݒ�")]
    public float detectRange = 5f;

    protected override void Move()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            // �v���C���[�Ɍ������Ĉړ�
            float direction = Mathf.Sign(player.position.x - transform.position.x);
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            Flip(direction);
        }
        else
        {
            // �v���C���[���͈͊O�Ȃ��~
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
