using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("プレイヤーHP")]
    public int hp = 3;
    public float invincibleTime = 1.0f;
    private float invincibleTimer = 0f;
    [SerializeField] private Vector3 defaultPosition = new Vector3(0.0f, -2.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 無敵時間カウント
        if (invincibleTimer > 0f)
        {
            invincibleTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibleTimer > 0f) return;

        hp -= damage;
        invincibleTimer = invincibleTime;

        Debug.Log($"Player took {damage} damage. HP now: {hp}");

        if (hp <= 0)
        {
            Debug.Log("プレイヤー死亡！");
            // 死亡処理などはここに追加
            hp = 3;
            transform.position = defaultPosition;
        }
    }
}
