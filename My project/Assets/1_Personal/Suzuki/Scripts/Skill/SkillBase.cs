using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    SKILL_TYPE _type;

    protected abstract void Effect();
}
