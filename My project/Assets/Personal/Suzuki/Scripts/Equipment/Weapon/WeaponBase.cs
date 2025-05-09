using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected int _defaultLevel = 1;
    private int _level;
    protected int _defaultHP = 10;
    private int _hp;
    protected WEAPON_TYPE _type;
    protected PlayerInventory _inventory;
    [SerializeField] protected Vector2 _attackPositionOffset = new Vector2(0.5f, 0.0f);

    protected GameObject _attack;

    void Start() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Destroy(gameObject);
        }
        _inventory = player.GetComponent<PlayerInventory>();
        if (_inventory == null)
        {
            Destroy(gameObject);
        }

        DoStart();
        _level = _defaultLevel;
        _hp = _defaultHP;
    }

    protected virtual void DoStart() { }

    void Update()
    {
        transform.localPosition = _inventory.GetWeaponPosition();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            _level--;
            if (_level < 1) {
                _level = 1;
            }

            _hp--;
            if(_hp <= 0)
            {
                Destroy(gameObject);
                _inventory.RemoveWeapon();
                _inventory.AddSkill(SKILL_TYPE.TYPE_1);
            }
        }
    }

    public WEAPON_TYPE GetWeaponType() { return _type; }
    public int GetWeaponHP() { return _hp; }
    public int GetWeaponDefaultHP() { return _defaultHP; }
    public virtual void Attack()
    {
        if (_attack == null) 
        {
            return;
        }
        GameObject atkObj;
        Vector3 ofst = _attackPositionOffset;
        atkObj = Instantiate(_attack);
        atkObj.transform.position = new Vector3(transform.position.x + ofst.x, transform.position.y + ofst.y, transform.position.z);
    }
}
