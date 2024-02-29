using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoints;
    private Score scr;

    public float addedArrows;
    private float addedTime;

    [Header("Movement")]
    public float speed;
    public GameObject target;
    private Rigidbody2D rb;

    [Header("animations")]
    public Animator animator;
    private bool IsDead;      //to stop the movement and other stuff

    [Header("sfx")]
    public AudioSource tear_src;
    public AudioClip tear_sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        scr = (Score)FindObjectOfType(typeof (Score));
        scr.enemyNum += 1;
        animator = gameObject.GetComponent<Animator>();

        addedTime = scr.addedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints < 1 && !IsDead)
        {
            scr.score += 1;        //added score
            scr.addMoney(scr.addedMoney + Random.Range(-2, 2));      //radnom + added money for each kill
            scr.arrowNum += addedArrows;  //added arrow on detah
            scr.time += addedTime + Random.Range(-0.2f, 0.2f);

            scr.enemyNum -= 1;
            tear_src.PlayOneShot(tear_sfx, 1f);
            Destroy(gameObject, 0.5f);
            IsDead = true;
            animator.SetTrigger("Death");
        }
        
        if (target == null)
        {
            GameObject[] archers = GameObject.FindGameObjectsWithTag("Archer");

            target = archers[Random.Range(0, archers.Length)];
        }
        else if (target != null && !IsDead)
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x ) > 0.2f)
            {
                if (target.transform.position.x > transform.position.x)
                {rb.velocity = new Vector2(speed, rb.velocity.y);}
                if (target.transform.position.x < transform.position.x)
                {rb.velocity = new Vector2(-speed, rb.velocity.y);}
            }
            else{rb.velocity = new Vector2(0, 0);}
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Arrow(Clone)")
        {
            healthPoints -= 1;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "border" && !IsDead)
        {
            scr.enemyNum -= 1;
            Destroy(gameObject, 0.5f);
            IsDead = true;
            animator.SetTrigger("Death");
        }
    }
}
