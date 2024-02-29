using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    private Rigidbody2D rb;

    private Transform CurrentPoint;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        CurrentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if (CurrentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else
        {
            rb.velocity = new Vector2(0, -speed);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == pointB.transform)
        {
            CurrentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 1.0f && CurrentPoint == pointA.transform)
        {
            CurrentPoint = pointB.transform;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
