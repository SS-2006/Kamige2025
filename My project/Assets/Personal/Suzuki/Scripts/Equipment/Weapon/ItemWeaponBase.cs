using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeaponBase : MonoBehaviour
{
    protected WEAPON_TYPE _type = WEAPON_TYPE.NONE;

    void Start()
    {
        DoStart();
    }

    virtual protected void DoStart() { }

    public WEAPON_TYPE GetWeaponType() { return _type; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inv = collision.gameObject.GetComponent<PlayerInventory>();
            if (inv.GetWeaponType() != WEAPON_TYPE.NONE)
            {
                return;
            }

            if (inv.AddWeapon(_type))
            {
                Destroy(gameObject);
            }
        }
    }
}
