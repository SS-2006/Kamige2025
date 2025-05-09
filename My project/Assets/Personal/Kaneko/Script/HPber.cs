//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPber : MonoBehaviour
{
    private float _myHp;
    private float _defaultHp;
    private Image _image;
    private WeaponBase _weapon;

    // Start is called before the first frame update
    private void Start()
    {
        _defaultHp = 10.0f;
        _myHp = _defaultHp;
        _image = this.GetComponent<Image>();
        //_weapon = this.GetComponent<WeaponBase>();
        //_defaultHp = _weapon.GetWeaponDefaultHP();
    }

    // Update is called once per frame
    void Update()
    {
        //rect.localScale=new Vector2()
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _myHp -= 1.0f * Time.deltaTime;
            if (_myHp< 0)
            {
                _myHp = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _myHp += 1.0f * Time.deltaTime;
            if (_myHp > _defaultHp)
            {
                _myHp = _defaultHp;
            }
        }

        //_image.fillAmount = _weapon.GetWeaponHP() / _defaultHp;

        _image.fillAmount = _myHp / _defaultHp;
    }
}
