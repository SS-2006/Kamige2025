using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    [Header("カメラ移動範囲")]
    float _cameraMoveRange = 100.0f;

    [SerializeField]
    [Header("追従するオブジェクト")]
    GameObject _targetObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetObject == null) {
            return;
        }

        Vector3 targetPosition = _targetObject.transform.position;

        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        if (transform.position.x > _cameraMoveRange)
        {
            transform.position = new Vector3(_cameraMoveRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < 0.0f)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
}
