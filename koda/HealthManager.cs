using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [Header("health")]
    public float healthPoints;
    public Vector3 spawnPoint;

    [Header("immunity frames")]
    public float immTime;
    private float currImmTime;


    [Header("ammo")]
    public float ammo;
    private float strtAmmo = 30f;
    public float currReloadTime;
    public float maxReloadTime;   //used in reload point to get scale factor

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currImmTime += 1 * Time.deltaTime;

        if (healthPoints <= 0)
        {
            healthPoints = 6;
            transform.position = spawnPoint;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Red" && currImmTime > immTime)
        {
            healthPoints -= 1;
            currImmTime = 0;
        }
    }

    public void Reload(float reloadTime)
    {
        currReloadTime += 1 * Time.deltaTime;
        maxReloadTime = reloadTime;

        if (currReloadTime> reloadTime)
        {
            ammo = strtAmmo;
            currReloadTime = 0;
        }
    }
}
