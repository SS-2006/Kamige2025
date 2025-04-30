using UnityEngine;

/// <summary>

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour
{
    [Header("���ʐݒ�")]
    public float moveSpeed = 2f;
    public int maxHP = 3;

    protected int currentHP;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;
    protected Transform player;
    protected bool isFacingRight = true;

    protected virtual void Awake()
    {
        // Rigidbody2D�擾�i�Ȃ���΃G���[�ɂȂ�̂ŕK������O��j
        rb = GetComponent<Rigidbody2D>();

        // BoxCollider2D���Ȃ�������t����
        col = GetComponent<BoxCollider2D>();
        if (col == null)
        {
            col = gameObject.AddComponent<BoxCollider2D>();
            col.isTrigger = false;           // �ʏ�̕����Փ˂ɂ���i�K�v�Ȃ�true�ɂł���j
            col.size = new Vector2(1.0f, 1.0f); // �T�C�Y�����l
        }
    }

    protected virtual void Start()
    {
        currentHP = maxHP;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogWarning($"�v���C���[��������܂���ł����BEnemyBase({name})");
        }
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Move();
        }
    }

    /// <summary>
    /// �ړ������i�q�N���X�ŃI�[�o�[���C�h�K�{�j
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// �_���[�W���󂯂�
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// ���S����
    /// </summary>
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// �����]���i�ړ������ɍ��킹�č��E���]�j
    /// </summary>
    protected void Flip(float moveDirection)
    {
        if ((moveDirection > 0 && !isFacingRight) || (moveDirection < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
