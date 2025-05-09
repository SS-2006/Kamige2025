using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    SKILL_TYPE _type = SKILL_TYPE.NONE;
    PlayerInventory inventory;

    protected abstract void Effect();
}
