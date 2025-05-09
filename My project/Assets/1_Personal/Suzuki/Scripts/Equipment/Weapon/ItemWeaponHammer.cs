using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeaponHammer : ItemWeaponBase
{
    protected override void DoStart()
    {
        _type = WEAPON_TYPE.TYPE_2;
    }
}
