using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponType1 : WeaponBase
{
    protected override void DoStart()
    {
        _type = WEAPON_TYPE.TYPE_1;
        _attack = (GameObject)Resources.Load("Prefab/SwordAttack");
        _defaultLevel = 5;
        _defaultHP = 10;
    }
}
