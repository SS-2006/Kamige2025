//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPber : MonoBehaviour
{
    //RectTransform rect;

    private float _myHp = 200.0f;
    private Image _image;

    // Start is called before the first frame update
    private void Start()
    {
        //rect = GetComponent<RectTransform>();
        _image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //rect.localScale=new Vector2()
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _myHp--;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            _myHp++;
        }

        _image.fillAmount = _myHp / 200.0f;
    }
}
