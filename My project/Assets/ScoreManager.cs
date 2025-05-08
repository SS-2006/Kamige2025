using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public GameObject score_object = null;
    //public float score_num = 0;

    public Text timerText;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Text score_text = score_object.GetComponent<Text>();
        //score_text.text = "Score" + score_num;
        //score_num += 0.01f;

        float t = Time.time - startTime;
        string seconds = t.ToString("f2");
        timerText.text = seconds;

    }
}
