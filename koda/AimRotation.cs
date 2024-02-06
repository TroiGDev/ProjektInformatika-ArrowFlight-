using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    public bool isMobile;
    [Header("pc/mb common")]
    public Camera cam;
    public float offset;
    public float speed;

    [Header("mobile")]
    public Joystick firingJs;

    void Start()
    {
        if (Application.isMobilePlatform)
        {isMobile = true;}else{isMobile = false;}
    }

    void Update()
    {
        if (!isMobile)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 relativePos = new Vector3(mousePos.x, mousePos.y, transform.position.z) - transform.position;                       //get each axis difference
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - offset;           //use atan func to get angle
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);                                  //set angle as quaternion
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed * 1000);        //slerp rotation with speed
        }

        if (isMobile)
        {
            //Debug.Log(firingJs.Direction);
            if (firingJs.Direction.y != 0)
            {
                Vector2 mousePos = new Vector3(transform.position.x + firingJs.Direction.x * 10, transform.position.y + firingJs.Direction.y * 10, 0f);
                Vector3 relativePos = new Vector3(mousePos.x, mousePos.y, transform.position.z) - transform.position;                       //get each axis difference
                float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - offset;           //use atan func to get angle
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);                                  //set angle as quaternion
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed * 1000);        //slerp rotation with speed
            }
        }
    }
}
