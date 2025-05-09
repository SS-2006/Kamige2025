using UnityEngine;

/// <summary>

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour
{
    [Header("共通設定")]
    public float moveSpeed = 2f;
    public int maxHP = 3;

    protected int currentHP;
    protected Rigidbody2D rb;
    protected BoxCollider2D col;
    protected Transform player;
    protected bool isFacingRight = true;

    protected virtual void Awake()
    {
        // Rigidbody2D取得（なければエラーになるので必ずある前提）
        rb = GetComponent<Rigidbody2D>();

        // BoxCollider2Dがなかったら付ける
        col = GetComponent<BoxCollider2D>();
        if (col == null)
        {
            col = gameObject.AddComponent<BoxCollider2D>();
            col.isTrigger = false;           // 通常の物理衝突にする（必要ならtrueにできる）
            col.size = new Vector2(1.0f, 1.0f); // サイズ初期値
        }
    }

    protected virtual void Start()
    {
        currentHP = maxHP;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogWarning($"プレイヤーが見つかりませんでした。EnemyBase({name})");
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
    /// 移動処理（子クラスでオーバーライド必須）
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// ダメージを受ける
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
    /// 死亡処理
    /// </summary>
    protected virtual void Die()
    {
        int ramdom = (int)Random.Range(0.0f, 2.0f);
        switch(ramdom)
        {
            case 0:
                {
                    Instantiate(Resources.Load("Prefab/ItemSword"), transform.position, transform.rotation);
                    break;
                }
            case 1:
                {
                    Instantiate(Resources.Load("Prefab/ItemHammer"), transform.position, transform.rotation);
                    break;
                }
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// 方向転換（移動方向に合わせて左右反転）
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

    //protected virtual void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // クラス参照せず "TakeDamage" を呼ぶ（存在しなくてもエラーにしない）
    //        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // クラス参照せず "TakeDamage" を呼ぶ（存在しなくてもエラーにしない）
            collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            AttackDamage atkDmg = collision.gameObject.GetComponent<AttackDamage>();
            TakeDamage(atkDmg.GetAttackPower());
        }
    }
}
