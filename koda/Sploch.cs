using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sploch : MonoBehaviour
{
    public float lifeTime;
    private float currLifeTime;

    public GameObject boxy;
    public float cooldown;
    private float currCooldown;

    [Header("effects")]
    public ParticleSystem explosion_pfx;
    public ParticleSystem explosion2_pfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currCooldown += 1 * Time.deltaTime;
        currLifeTime += 1 * Time.deltaTime;

        if(currLifeTime> lifeTime)
        {
            explosion_pfx.Play();
            explosion2_pfx.Play();
            Destroy(gameObject, 0.3f);
        }
        if (currCooldown > cooldown)
        {
            Instantiate(boxy, transform.position, Random.rotation);
            currCooldown = 0;
        }
    }
}
