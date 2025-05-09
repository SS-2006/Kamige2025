using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeaponSword : ItemWeaponBase
{
    protected override void DoStart()
    {
        _type = WEAPON_TYPE.TYPE_1;
    }
}
