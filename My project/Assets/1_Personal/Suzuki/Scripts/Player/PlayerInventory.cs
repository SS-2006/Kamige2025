using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WEAPON_TYPE _weapon = WEAPON_TYPE.NONE;
    private ARMOR_TYPE _armor = ARMOR_TYPE.NONE;
    private List<SKILL_TYPE> _skillList;
    [SerializeField] protected Vector2 _weaponPositionOffset = new Vector2(1.0f, 1.0f);

    void Start()
    {
        int ramdom = (int)Random.Range(0.0f, 1.0f);
        switch(ramdom)
        {
            case 0:
                {
                    AddWeapon(WEAPON_TYPE.TYPE_1);
                    break;
                }
            case 1:
                {
                    AddWeapon(WEAPON_TYPE.TYPE_2);
                    break;
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Weapon")
        {
            WeaponBase wpn = obj.GetComponent<WeaponBase>();
            if (wpn == null) {
                AddWeapon(wpn.GetWeaponType());
            }
        }
        else if (obj.tag == "Armor")
        {
            ArmorBase amr = obj.GetComponent<ArmorBase>();
            if (amr == null) { 
                AddArmor(amr.GetArmorType()); 
            }
        }
    }

    public WEAPON_TYPE GetWeaponType() { return _weapon; }
    public ARMOR_TYPE GetArmorType() { return _armor; }
    public List<SKILL_TYPE> GetSkillList() { return _skillList; }
    public Vector3 GetWeaponPosition() 
    { 
        return new Vector3(transform.position.x + _weaponPositionOffset.x, 
                           transform.position.y + _weaponPositionOffset.y,
                           transform.position.z); 
    }

    public void AddWeapon(WEAPON_TYPE wpnType) 
    {
        _weapon = wpnType;
        switch(_weapon)
        {
            case WEAPON_TYPE.TYPE_1:
                {
                    GameObject wpnObj = Instantiate((GameObject)Resources.Load("Prefab/Sword"));
                    wpnObj.GetComponent<Transform>().position = GetWeaponPosition();
                    break;
                }
            case WEAPON_TYPE.TYPE_2:
                {
                    GameObject wpnObj = Instantiate((GameObject)Resources.Load("Prefab/Hammer"));
                    wpnObj.GetComponent<Transform>().position = GetWeaponPosition();
                    break;
                }
        }
    }
    public void AddArmor(ARMOR_TYPE amrType) 
    { 
        _armor = amrType;
        switch (_armor)
        {
            case ARMOR_TYPE.TYPE_1:
                {
                    
                    break;
                }
            case ARMOR_TYPE.TYPE_2:
                {
                    
                    break;
                }
        }
    }
    public void AddSkill(SKILL_TYPE sklType)
    { 
        _skillList.Add(sklType);
        switch (sklType)
        {
            case SKILL_TYPE.TYPE_1:
                {
                    //this.AddComponent<>();
                    break;
                }
            case SKILL_TYPE.TYPE_2:
                {
                    //this.AddComponent<>();
                    break;
                }
            case SKILL_TYPE.TYPE_3:
                {
                    //this.AddComponent<>();
                    break;
                }
            case SKILL_TYPE.TYPE_4:
                {
                    //this.AddComponent<>();
                    break;
                }
        }
    }

    public void RemoveWeapon()
    {
        _weapon = WEAPON_TYPE.NONE;
    }
}
