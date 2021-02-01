using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    #region fields

    private float _dirX;
    private float _dirY;
    private Quaternion _eulerAngleRotation;

    #endregion


    #region Methods

    void Update()
    {
        //Getting data from the gyro sensor
        _dirX = Input.acceleration.x; 

        if (_dirX > 0.7f)
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        
        if (_dirX < -0.7f)
        {
            transform.rotation = Quaternion.Euler(270, 0, 0);
        }

        if (_dirX > -0.3f && _dirX < 0.3f )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    #endregion
    
    
}
