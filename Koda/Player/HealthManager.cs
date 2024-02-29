using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int healthPoints;

    private Score scr;

    [Header("gets hit")]
    public Vector2 knockbackForce;
    public Rigidbody2D rb;

    public float immunityFrames;
    private float strtImmFrames;

    [Header("dies")]
    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        strtImmFrames = immunityFrames;
        spawnPoint = transform.position;
        scr = (Score)FindObjectOfType(typeof (Score));
    }

    // Update is called once per frame
    void Update()
    {
        immunityFrames -= 1 * Time.deltaTime;
    	
        /*
        if (healthPoints < 1 || Mathf.Abs(transform.position.x) + Mathf.Abs(transform.position.y) > 100)
        {
            transform.position = spawnPoint;
            healthPoints = 10;
            scr.addMoney(scr.score);
            scr.score = 0;
            scr.arrowNum = 10;
        }
        */
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Enemy" || col.name == "Enemy(Clone)")
        {
            if (immunityFrames < 0)      //immunity frames, if its more than negative its active
            {
                healthPoints -= 1;
                knockback(knockbackForce, col.gameObject);
                immunityFrames = strtImmFrames;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "border")
        {
            transform.position = spawnPoint;
        }
    }

    void knockback(Vector2 force, GameObject inflictor)
    {
        if (inflictor.transform.position.x >= transform.position.x)
        {
            rb.velocity = new Vector2( rb.velocity.x - force.x, rb.velocity.y + force.y);
        }
        if (inflictor.transform.position.x < transform.position.x)
        {
            rb.velocity = new Vector2( rb.velocity.x + force.x, rb.velocity.y + force.y);
        }
    }
}
