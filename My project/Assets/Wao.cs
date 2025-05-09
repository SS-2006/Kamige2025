using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wao : MonoBehaviour
{
    float seconds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 2)
        {
            seconds = 0;
            Debug.Log("2ïbå„Ç…é¿çsÇ≥ÇÍÇΩ");
        }
    }
}
