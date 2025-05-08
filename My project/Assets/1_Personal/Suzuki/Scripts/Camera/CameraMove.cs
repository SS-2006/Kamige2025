using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject _targetObject;
    [SerializeField] Vector2 _cameraPositionOffset = new Vector2(0.0f, 1.0f);
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

        transform.position = new Vector3(targetPosition.x + _cameraPositionOffset.x, 
                                         targetPosition.y + _cameraPositionOffset.y, 
                                         transform.position.z);
    }
}
