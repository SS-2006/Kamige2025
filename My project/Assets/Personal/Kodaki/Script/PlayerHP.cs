using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("�v���C���[HP")]
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
        // ���G���ԃJ�E���g
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
            Debug.Log("�v���C���[���S�I");
            // ���S�����Ȃǂ͂����ɒǉ�
            hp = 3;
            transform.position = defaultPosition;
        }
    }
}
