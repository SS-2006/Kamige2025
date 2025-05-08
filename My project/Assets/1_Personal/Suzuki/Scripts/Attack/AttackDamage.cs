using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private int ATTACK_POWER = 10;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetAttack() { return ATTACK_POWER; }
}
