using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;
    public bool HasHit;
    private Vector3 hitPoint;

    [Header("sound effects")]
    public AudioSource shoot_src;
    public AudioClip shoot_sfx;

    public AudioSource hit_src;
    public AudioClip hit_sfx;

    [Header("particle effecty")]
    public ParticleSystem impact_pfx;

    [Header("on death spawn")]
    public GameObject boxy;
    public float percentChance;
    
    // Start is called before the first frame update
    void Start()
    {
        shoot_src.PlayOneShot(shoot_sfx);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= 1 * Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(gameObject,0.2f);
        }

        if (HasHit)
        {
            transform.position = hitPoint;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name != "Bullet_sng(Clone)" && !HasHit)
        {
            HasHit = true;
            hit_src.PlayOneShot(hit_sfx);
            impact_pfx.Play();
            hitPoint = transform.position;

            float random = Random.Range(0f, 1f);
            if (random < percentChance)
            {Instantiate(boxy, transform.position, Quaternion.identity);}

            Destroy(gameObject, 0.2f);        //can be removed for paint splatter
        }
    }
}
