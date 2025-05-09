using UnityEngine;

public class EnemyShoot : EnemyBase
{
    [Header("�e���ːݒ�")]
    public GameObject bulletPrefab;
    public float fireInterval = 2f;
    public Transform firePoint;

    [Header("��2�t�F�[�Y�i���i�e�j")]
    public int multiBulletCount = 5;
    public float spreadAngle = 60f;

    [Header("�ߐڍU���i��2�t�F�[�Y�j")]
    public float attackRange = 1.5f;
    public float meleeCooldown = 3f;

    [Header("�����蔻��T�C�Y�i���̓G�����j")]
    public Vector2 customColliderSize = new Vector2(3.5f, 3.5f);

    private float shootTimer;
    private float meleeTimer;
    private bool phase2 = false;

    protected override void Awake()
    {
        base.Awake();

        // ���̓G��p�̓����蔻��T�C�Y��ݒ�
        if (col != null)
        {
            col.size = customColliderSize;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (player == null) return;

        // HP�����Ńt�F�[�Y2��
        if (!phase2 && currentHP <= maxHP / 2)
        {
            phase2 = true;
            Debug.Log("�t�F�[�Y2�ɓ˓��I�i���i�e + �ߐځj");
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
                Debug.Log("[Debug] �t�F�[�Y2 �� ShootMultipleBullets() ���Ă�");
                ShootAtPlayerMultiple(5, 45f); // 5���A45�x�΂炯��ǔ��e
            }
        }

        // �t�F�[�Y2�F�ߐڍU���ǉ�
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

    // �ߐڍU���i�v���C���[���߂����j
    private void MeleeAttack()
    {
        Debug.Log("�ߐڍU���I");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange);
        if (hit != null && hit.CompareTag("Player"))
        {
            hit.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    protected override void Move()
    {
        // �ړ����Ȃ��i�Œ�^�j
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
