using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject boxy;
    public float cooldown;
    private float currCooldown;

    [Header("Position")]
    public float halfX;
    public float halfY;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currCooldown+= 1 * Time.deltaTime;
        if (currCooldown > cooldown)
        {
            Instantiate(boxy, new Vector3(Random.Range(-halfX, halfX), Random.Range(-halfY, halfY), z), Quaternion.identity);
            currCooldown = 0;
        }
    }
}
