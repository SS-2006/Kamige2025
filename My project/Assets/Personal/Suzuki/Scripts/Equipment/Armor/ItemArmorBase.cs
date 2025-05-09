using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArmorBase : MonoBehaviour
{
    protected ARMOR_TYPE _type = ARMOR_TYPE.NONE;

    void Start()
    {
        DoStart();
    }

    virtual protected void DoStart() { }

    public ARMOR_TYPE GetArmorType() { return _type; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory inv = collision.gameObject.GetComponent<PlayerInventory>();
            if (inv.GetArmorType() != ARMOR_TYPE.NONE)
            {
                return;
            }

            if (inv.AddArmor(_type))
            {
                Destroy(gameObject);
            }
        }
    }
}
