using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private int ATTACK_POWER = 10;
    private PlayerInventory _playerInventory; 

    void Start()
    {
        GameObject plyr = GameObject.FindGameObjectWithTag("Player");
        _playerInventory = plyr.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        
    }

    public int GetAttackPower() 
    {
        int atkPwr = 0;
        List<SKILL_TYPE> sklList;

        sklList = _playerInventory.GetSkillList();

        for (int i = 0; i < sklList.Count; i++)
        {
            switch(sklList[i])
            {
                case SKILL_TYPE.TYPE_1:
                    {
                        atkPwr += 2;
                        break;
                    }
            }
        }
        

        return atkPwr + ATTACK_POWER; 
    }
}
