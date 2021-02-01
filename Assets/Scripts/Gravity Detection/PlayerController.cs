using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Joystick joystick;
    public float moveSpeed = 15;
    private Vector3 _moveDir;

    #endregion


    #region Methods

    void Update()
    {
        _moveDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(_moveDir) * moveSpeed * Time.deltaTime);
    }

    #endregion
   
}
