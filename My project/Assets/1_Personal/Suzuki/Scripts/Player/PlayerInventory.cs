using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WEAPON_TYPE _weapon = WEAPON_TYPE.NONE;
    private ARMOR_TYPE _armor = ARMOR_TYPE.NONE;
    private List<SKILL_TYPE> _skillList = new List<SKILL_TYPE>();
    [SerializeField] protected Vector2 _weaponPositionOffset = new Vector2(0.1f, 0.0f);

    void Start()
    {
        int ramdom = (int)Random.Range(0.0f, 2.0f);
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

    private void Update()
    {
        
    }

    public WEAPON_TYPE GetWeaponType() { return _weapon; }
    public ARMOR_TYPE GetArmorType() { return _armor; }
    public List<SKILL_TYPE> GetSkillList() { return _skillList; }
    public Vector3 GetWeaponPosition() 
    { 
        return _weaponPositionOffset;
    }

    public bool AddWeapon(WEAPON_TYPE wpnType) 
    {
        _weapon = wpnType;
        switch(_weapon)
        {
            case WEAPON_TYPE.TYPE_1:
                {
                    GameObject wpnObj = Instantiate((GameObject)Resources.Load("Prefab/Sword"), Vector3.zero, Quaternion.identity, this.transform);
                    break;
                }
            case WEAPON_TYPE.TYPE_2:
                {
                    GameObject wpnObj = Instantiate((GameObject)Resources.Load("Prefab/Hammer"), Vector3.zero, Quaternion.identity, this.transform);
                    break;
                }
            case WEAPON_TYPE.NONE:
                {
                    return false;
                }
        }

        return true;
    }
    public bool AddArmor(ARMOR_TYPE amrType) 
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
            case ARMOR_TYPE.NONE:
                {
                    return false;
                }
        }

        return true;
    }
    public void AddSkill(SKILL_TYPE sklType)
    { 
        _skillList.Add(sklType);
        switch (sklType)
        {
            case SKILL_TYPE.TYPE_1:
                {
                    //this.AddComponent<>();
                    Debug.Log("çUåÇóÕëùâ¡ÉXÉLÉãéÊìæ");
                    break;
                }
        }

        
    }

    public void RemoveWeapon()
    {
        _weapon = WEAPON_TYPE.NONE;
    }
}
