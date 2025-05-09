using UnityEngine;

public class BossEnemy : EnemyBase
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float attackCooldown = 2f;

    private float cooldownTimer = 0f;
    private bool phase2 = false;

    protected override void Move()
    {
        if (player == null) return;

        // HPが半分以下で第2フェーズへ
        if (currentHP <= maxHP / 2 && !phase2)
        {
            phase2 = true;
            Debug.Log("第2フェーズに突入！");
        }

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            if (!phase2)
            {
                Punch(); // フェーズ1：近接攻撃
            }
            else
            {
                ShootProjectile(); // フェーズ2：弾を撃つ
            }

            cooldownTimer = attackCooldown;
        }
    }

    //  タグ方式の近接攻撃
    void Punch()
    {
        Debug.Log("ボスがパンチ攻撃！");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1.5f);
        if (hit != null && hit.CompareTag("Player"))
        {
            Debug.Log("プレイヤーにヒット！");
            // 任意でメッセージ送信
            hit.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    //  弾を発射する処理
    void ShootProjectile()
    {
        Debug.Log("ボスが弾を撃った！");
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        }
    }

    //  近接範囲表示（Sceneビュー用）
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
