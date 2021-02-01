using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    #region Fields

    public float gravity = -10;

    #endregion


    #region Methods

    /// <summary>
    /// This method will attract the body with it. Mainly it is working as a magnet.
    /// Moreover, it is maintaining the rotation part of the gravity body.
    /// </summary>
    /// <param name="body"></param>
    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        
        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }

    #endregion
}
