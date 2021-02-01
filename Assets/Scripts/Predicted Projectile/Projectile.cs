using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Projectile : MonoBehaviour
{
    #region Fields

    public Rigidbody projectile;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public LineRenderer lineVisual;
    public int lineSegment = 10;
    public float flightTime = 1f;
 
    private Camera cam;

    #endregion


    #region Methods

     void Start()
    {
        cam = Camera.main;
        lineVisual.positionCount = lineSegment + 1;
    }
    
    
    void Update()
    {
        LaunchProjectile();
    }
 
    /// <summary>
    /// give the projected value in every frame
    /// get the mouse position or touch position 
    /// </summary>
    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
 
        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;
 
            Vector3 vo = CalculateVelocty(hit.point, shootPoint.position, flightTime);
 
            //we include the cursor position as the final nodes for the line visual position
            Visualize(vo, cursor.transform.position); 
 
            transform.rotation = Quaternion.LookRotation(vo);
            
        }
    }
    /// <summary>
    /// added final position argument to draw the last line node to the actual target
    /// </summary>
    /// <param name="vo"></param>
    /// <param name="finalPos"></param>
    void Visualize(Vector3 vo, Vector3 finalPos)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, (i / (float)lineSegment) * flightTime);
            lineVisual.SetPosition(i, pos);
        }
 
        lineVisual.SetPosition(lineSegment, finalPos);
    }
 
    /// <summary>
    /// applied Projectile formula here
    /// </summary>
    /// <param name="target"></param>
    /// <param name="origin"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;
 
        float sY = distance.y;
        float sXz = distanceXz.magnitude;
 
        float Vxz = sXz / time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);
 
        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;
 
        return result;
    }
 
    /// <summary>
    /// calculate the time according to gravity, force and shooting time
    /// </summary>
    /// <param name="vo"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;
 
        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;
 
        result.y = sY;
 
        return result;
    }

    #endregion
   
}