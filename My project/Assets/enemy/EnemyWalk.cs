using UnityEngine;

public class EnemyWalk : EnemyBase
{
    private int moveDirection = 1; // �E�����i1�j�܂��͍������i-1�j

    protected override void Move()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    // �Ⴆ�΁A�ǂɓ�������������]���Ƃ�����ő�����
}
