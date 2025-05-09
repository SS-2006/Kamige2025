using UnityEngine;

public class EnemyShoot : EnemyBase
{
    [Header("弾発射設定")]
    public GameObject bulletPrefab;
    public float fireInterval = 2f;
    public Transform firePoint;

    [Header("第2フェーズ（多段弾）")]
    public int multiBulletCount = 5;
    public float spreadAngle = 60f;

    [Header("近接攻撃（第2フェーズ）")]
    public float attackRange = 1.5f;
    public float meleeCooldown = 3f;

    [Header("当たり判定サイズ（この敵だけ）")]
    public Vector2 customColliderSize = new Vector2(3.5f, 3.5f);

    private float shootTimer;
    private float meleeTimer;
    private bool phase2 = false;

    protected override void Awake()
    {
        base.Awake();

        // この敵専用の当たり判定サイズを設定
        if (col != null)
        {
            col.size = customColliderSize;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (player == null) return;

        // HP半分でフェーズ2へ
        if (!phase2 && currentHP <= maxHP / 2)
        {
            phase2 = true;
            Debug.Log("フェーズ2に突入！（多段弾 + 近接）");
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= fireInterval)
        {
            shootTimer = 0f;

            if (!phase2)
            {
                ShootAtPlayer();
            }
            else
            {
                Debug.Log("[Debug] フェーズ2 → ShootMultipleBullets() を呼ぶ");
                ShootAtPlayerMultiple(5, 45f); // 5発、45度ばらける追尾弾
            }
        }

        // フェーズ2：近接攻撃追加
        if (phase2)
        {
            meleeTimer += Time.deltaTime;
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= attackRange && meleeTimer >= meleeCooldown)
            {
                meleeTimer = 0f;
                MeleeAttack();
            }
        }
    }

    private void ShootAtPlayer()
    {
        if (bulletPrefab == null || firePoint == null || player == null) return;

        Vector2 direction = (player.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        var bulletComp = bullet.GetComponent<EnemyBullet>();
        if (bulletComp != null)
        {
            bulletComp.SetDirection(direction);
        }
    }

    private void ShootAtPlayerMultiple(int count, float angleRange)
    {
        if (bulletPrefab == null || firePoint == null || player == null || count <= 0) return;

        Vector2 toPlayer = (player.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;

        float angleStep = angleRange / (count - 1);
        float startAngle = baseAngle - angleRange / 2f;

        for (int i = 0; i < count; i++)
        {
            float angle = startAngle + angleStep * i;
            Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.right;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            var bulletComp = bullet.GetComponent<EnemyBullet>();
            if (bulletComp != null)
            {
                bulletComp.SetDirection(dir);
            }
        }
    }

    // 近接攻撃（プレイヤーが近い時）
    private void MeleeAttack()
    {
        Debug.Log("近接攻撃！");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange);
        if (hit != null && hit.CompareTag("Player"))
        {
            hit.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    protected override void Move()
    {
        // 移動しない（固定型）
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
