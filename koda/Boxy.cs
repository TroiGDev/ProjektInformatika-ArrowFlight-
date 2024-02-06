using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Boxy : MonoBehaviour
{

    public float team;
    public GameObject target;

    public float speed;

    private Rigidbody2D rb;

    public float lifeTime;
    private float currLifeTime;

    [Header("effects")]
    public ParticleSystem explosion_pfx;

    [Header("Colores")]
    public Color[] colors;
    public SpriteRenderer sr;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = colors[Random.Range(0, colors.Length - 1)];

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currLifeTime += 1 * Time.deltaTime;
        if(currLifeTime > lifeTime)
        {
            explosion_pfx.Play();
            Destroy(gameObject, 0.3f);
        }
    
        if (target == null)
        {
            if (team == 1)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Blue");
                List<GameObject> enemiesList = enemies.ToList();
                GameObject[] sortedEnemies = enemiesList.OrderBy(obj =>  Mathf.Abs(Mathf.Abs(transform.position.x - obj.transform.position.x ) + Mathf.Abs(transform.position.y - obj.transform.position.y))).ToArray();
                if (sortedEnemies.Length > 0)
                {target = sortedEnemies[0];}
            }

            if (team ==0)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Red");
                List<GameObject> enemiesList = enemies.ToList();
                GameObject[] sortedEnemies = enemiesList.OrderBy(obj =>  Mathf.Abs(Mathf.Abs(transform.position.x - obj.transform.position.x ) + Mathf.Abs(transform.position.y - obj.transform.position.y))).ToArray();
                if (sortedEnemies.Length > 0)
                {target = sortedEnemies[0];}
            }
        }

        if (target != null)
        {
            Vector2 mousePos = target.transform.position;
            Vector3 relativePos = new Vector3(mousePos.x, mousePos.y, transform.position.z) - transform.position;                       //get each axis difference
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;           //use atan func to get angle
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);                                  //set angle as quaternion
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed * 1000);        //slerp rotation with speed

            rb.velocity = transform.right * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (team == 0)
        {
            if (col.gameObject.tag == "Red")
            {
                explosion_pfx.Play();
                Destroy(gameObject, 0.3f);
            }
        }

        if (team == 1)
        {
            if (col.gameObject.tag == "Blue")
            {
                explosion_pfx.Play();
                Destroy(gameObject, 0.3f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (team == 0)
        {
            if (col.gameObject.tag == "Red")
            {
                explosion_pfx.Play();
                Destroy(gameObject, 0.3f);
            }
        }

        if (team == 1)
        {
            if (col.gameObject.tag == "Blue")
            {
                explosion_pfx.Play();
                Destroy(gameObject, 0.3f);
            }
        }
    }
}
