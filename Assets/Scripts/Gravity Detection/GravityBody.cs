using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{

    #region MyRegion

    public GravityAttractor attractor;
    private Transform _myTransform;

    #endregion


    #region Methods

    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        _myTransform = transform;
    }
    
    void Update()
    {
        //This is sending the body to the GravityAttractor.
        attractor.Attract(_myTransform);
    }

    #endregion
    
}
