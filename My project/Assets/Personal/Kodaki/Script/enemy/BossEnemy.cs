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

        // HP�������ȉ��ő�2�t�F�[�Y��
        if (currentHP <= maxHP / 2 && !phase2)
        {
            phase2 = true;
            Debug.Log("��2�t�F�[�Y�ɓ˓��I");
        }

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            if (!phase2)
            {
                Punch(); // �t�F�[�Y1�F�ߐڍU��
            }
            else
            {
                ShootProjectile(); // �t�F�[�Y2�F�e������
            }

            cooldownTimer = attackCooldown;
        }
    }

    //  �^�O�����̋ߐڍU��
    void Punch()
    {
        Debug.Log("�{�X���p���`�U���I");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1.5f);
        if (hit != null && hit.CompareTag("Player"))
        {
            Debug.Log("�v���C���[�Ƀq�b�g�I");
            // �C�ӂŃ��b�Z�[�W���M
            hit.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    //  �e�𔭎˂��鏈��
    void ShootProjectile()
    {
        Debug.Log("�{�X���e���������I");
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        }
    }

    //  �ߐڔ͈͕\���iScene�r���[�p�j
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
