using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTime : MonoBehaviour
{
    [SerializeField] private float ATTACK_TIME = 1;
    private float _time = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > ATTACK_TIME)
        {
            Destroy(gameObject);
        }
    }
}
