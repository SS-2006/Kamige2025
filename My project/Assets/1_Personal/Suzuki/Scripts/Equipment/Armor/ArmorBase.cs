using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmorBase : MonoBehaviour
{
    [SerializeField] protected int DEFAULT_LEVEL = 1;
    protected int _level;
    [SerializeField] protected int DEFAULT_HP = 10;
    protected int _hp;
    protected ARMOR_TYPE _type;

    private void Start()
    {
        _level = DEFAULT_LEVEL;
        _hp = DEFAULT_HP;
        DoStart();
    }

    protected virtual void DoStart() { }

    public ARMOR_TYPE GetArmorType() { return _type; }

    public void Damage(int val) 
    { 
        _hp -= val;
        if (_hp < 0)
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Enemy")
        {
            //“G‚ÌƒNƒ‰ƒX‚ðŽæ“¾

            //“G‚ª—^‚¦‚éƒ_ƒ[ƒW‚ðŽæ“¾‚µ‚Ä‚»‚Ì”’l•ªHP‚ðŒ¸‚ç‚·
        }
    }
}
