using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Joystick joystick;

    [SerializeField] private float force;

    [SerializeField] private ForceMode forceMode;

    private Rigidbody _playerRb;

    #endregion


    #region Methods

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDir = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;
        _playerRb.AddForce(moveDir * force , forceMode);
    }

    public void Rotate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
    }

    #endregion

    
}
