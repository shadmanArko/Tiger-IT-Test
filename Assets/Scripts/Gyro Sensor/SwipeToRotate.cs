using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeToRotate : MonoBehaviour
{
    #region Fields

    private Touch _touch;
    private Vector2 _touchPosition;
    private Quaternion _rotationY;
    private float _rotationSpeedModifier = 0.1f;

    #endregion


    #region Methods

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                _rotationY = Quaternion.Euler(0f, -_touch.deltaPosition.x * _rotationSpeedModifier, 0f);
                transform.rotation = _rotationY * transform.rotation;
            }
        }
    }

    #endregion
    
}
