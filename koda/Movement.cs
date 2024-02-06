using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMobile;

    [Header("pc/mb common")]
    private Rigidbody2D rb;
    public float speed;

    [Header("Mobile")]
    public Canvas canvas;
    public Joystick movementJs;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {isMobile = true;}else{isMobile = false;}

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMobile)
        {
            canvas.enabled = false;

            if (Input.GetKey(KeyCode.W))
            {rb.velocity = new Vector3(rb.velocity.x, speed, 0);}
            if (Input.GetKey(KeyCode.A))
            {rb.velocity = new Vector3(-speed, rb.velocity.y, 0);}
            if (Input.GetKey(KeyCode.S))
            {rb.velocity = new Vector3(rb.velocity.x, -speed, 0);}
            if (Input.GetKey(KeyCode.D))
            {rb.velocity = new Vector3(speed, rb.velocity.y, 0);}
            
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {rb.velocity = new Vector3(rb.velocity.x, 0, 0);}
            if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {rb.velocity = new Vector3(0, rb.velocity.y, 0);}
        }

        if (isMobile)
        {
            canvas.enabled = true;

            if(movementJs.Direction.y != 0)
            {
                rb.velocity = new Vector2(movementJs.Direction.x * speed, movementJs.Direction.y * speed);
            } 
            else
            {
                rb.velocity = new Vector2(0f, 0f);
            } 
        }
    }
}
