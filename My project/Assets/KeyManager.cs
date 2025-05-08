using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class KeyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI countText;

    private int count;
    private float timeReset;
    private float time;

    void Start()
    {
        count = 0;
        time = 0;
        timeReset = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > timeReset) 
        {
            if (Input.GetKey(KeyCode.UpArrow) && count < 10)
            {
                count++;
                time = 0;
            }

            if (Input.GetKey(KeyCode.DownArrow) && count > 0)
            {
                count--;
                time = 0;
            }
        }

        countText.text = count.ToString();
    }
}
