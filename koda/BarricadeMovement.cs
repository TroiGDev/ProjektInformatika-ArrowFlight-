using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeMovement : MonoBehaviour
{
    public bool Rotate;
    public bool Move;

    [Header("Rotation")]
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate)
        {
            transform.Rotate(0, 0, rotSpeed);
        }
    }
}
