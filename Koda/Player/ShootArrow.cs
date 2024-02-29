using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject arrow;
    public float forceFactor;
    public float strengthFactor;

    public Transform bowPos;  //position to shoot from

    [Header("shoot points")]
    public Camera personalCam;
    public Transform point1;
    public Transform point2;

    [Header("Line")]
    public LineRenderer line;
    public float lineWidth;
    public Color lineColor;

    private bool hasMoved;

    [Header("arrrow mode")]
    private Score scr;

    [Header("trajectory points")]
    public GameObject pointPrefab;        //gets points prfeab
    public GameObject[] points;           //point array to set their position
    public int numPoints;                 //array size
    public float spaceBetweenPoints;      //time factor for vector 2 point poisiton func

    private Vector2 velocity;             //velocity in global format for use in point position func


    [Header("Animations")]
    private Rigidbody2D rb;
    private Animator animator;

    private bool IsShooting;
    public bool IsTeleporting;

    [Header("Pfx")]
    public ParticleSystem Teleport_pfx;
    public ParticleSystem Shoot_pfx;

    [Header("sfx")]
    public AudioSource shoot_src;
    public AudioClip shoot_sfx;

    public AudioSource impact_src;
    public AudioClip impact_sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        scr = (Score)FindObjectOfType(typeof (Score)); 

        points = new GameObject[numPoints];                //instantiates points for trajectory
        for (int i = 0; i < numPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, bowPos.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 1;
        animator.SetFloat("VelocityY", rb.velocity.y);

        if (IsShooting)
        {animator.SetBool("IsShooting", true);}
        else if (!IsShooting)
        {animator.SetBool("IsShooting", false);}

        if (IsTeleporting)
        {animator.SetBool("IsTeleporting", true);}
        else if (!IsTeleporting)
        {animator.SetBool("IsTeleporting", false);}

        //line shit (idk why there is so many parameters like gjaddam)
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.startColor = lineColor;
        line.endColor = lineColor;
        line.SetPosition(0, new Vector3(point1.position.x, point1.position.y, point1.position.z + 0.1f));       //line.SetPosition(index of the position in the vertecies array, x and y pos (and z));
        line.SetPosition(1, new Vector3(point2.position.x, point2.position.y, point2.position.z + 0.1f));

        if (Input.touchCount > 0)
        {
            Touch touch1 = Input.GetTouch(0);

            if (touch1.phase == TouchPhase.Began)
            {
                point1.position = personalCam.ScreenToWorldPoint(touch1.position);
                point1.position = new Vector3(point1.position.x, point1.position.y, -0.5f);  //sets the z correctly
            }

            if (touch1.phase == TouchPhase.Moved)
            {
                point2.position = personalCam.ScreenToWorldPoint(touch1.position);
                point2.position = new Vector3(point2.position.x, point2.position.y, -0.5f);  //sets the z correctly
                hasMoved = true;

                velocity = new Vector2(point1.position.x - point2.position.x, point1.position.y - point2.position.y) * forceFactor;   //calculates correct velociyt for trajectory line once

                for (int i = 0; i < numPoints; i++)  //sets points for trajectory at their position in space
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                }
            }

            if (touch1.phase == TouchPhase.Ended && hasMoved)
            {
                velocity = new Vector2(point1.position.x - point2.position.x, point1.position.y - point2.position.y) * forceFactor;   //secondtime for acctual velocity
                    
                Shoot(velocity);
                hasMoved = false;
            }
        }
        else
        {
            point1.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 100f);   //get points out of camera
            point2.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 100f);

            for (int i = 0; i < numPoints; i++)  //resets point pos to 0 to get them out of air while not aiming
            {
                points[i].transform.position = new Vector2(transform.position.x + 1000f, transform.position.y + 1000);
            }
        }
    }

    public void Shoot(Vector2 velocity)
    {
        IsShooting = true;
        GameObject Arrow = Instantiate(arrow, bowPos.position, Quaternion.Euler(0, 0, -90));
        Arrow.GetComponent<Rigidbody2D>().velocity = velocity;
        Arrow.GetComponent<ArrowCollisions>().owner = gameObject;
        Arrow.GetComponent<Arrow>().strength = (Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y)) * strengthFactor;
        Shoot_pfx.Play();
        shoot_src.PlayOneShot(shoot_sfx, 1f);

        //scr.arrowNum -= 1;
    }

    Vector2 PointPosition(float t)      //get each trajectory point pos, used to generate a position for each point by time(space between points)
    {
        Vector2 pointPosition = (Vector2)bowPos.position +  (velocity * t) + 0.5f * Physics2D.gravity * (t * t);    //some newtons shizzy
        Vector3 finalPosition = new Vector3(pointPosition.x, pointPosition.y, transform.position.z + 0.5f);         //sets z accordingly
        return finalPosition;
    }

    public void endShooting_anim()
    {IsShooting = false;
    animator.SetBool("IsShooting", false);
    Debug.Log("ended animation");}
    public void endTeleporting_anim()
    {IsTeleporting = false;
    animator.SetBool("IsTeleporting", false);
    Debug.Log("ended animation");}
}
