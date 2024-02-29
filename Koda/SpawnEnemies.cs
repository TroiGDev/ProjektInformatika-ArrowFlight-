using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private Score scr;

    [Header("enemyspawn")]
    public GameObject enemyPrefab;
    public float maxNum;

    [Header("Random position")]
    public GameObject[] spawnFields;
    

    // Start is called before the first frame update
    void Start()
    {
        scr = (Score)FindObjectOfType(typeof (Score));
    }

    // Update is called once per frame
    void Update()
    {
        if (scr.enemyNum < maxNum)
        {
            //get random position through spawn fields
            GameObject field = spawnFields[Random.Range(0, spawnFields.Length)];

            //gets 2 points of the field
            GameObject child1 = field.transform.GetChild(0).gameObject;
            GameObject child2 = field.transform.GetChild(1).gameObject;

            Vector2 pos1 = child1.transform.position;
            Vector2 pos2 = child2.transform.position;

            //gets random vertex in between the 2 points
            Vector3 finalPosition = new Vector3(Random.Range(pos1.x, pos2.x), Random.Range(pos1.y, pos2.y), 0.3f);

            Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < spawnFields.Length; i++)
        {
            //get random position through spawn fields
            GameObject field = spawnFields[i];

            //gets 2 points of the field
            GameObject child1 = field.transform.GetChild(0).gameObject;
            GameObject child2 = field.transform.GetChild(1).gameObject;

            Vector2 pos1 = child1.transform.position;
            Vector2 pos2 = child2.transform.position;

            Gizmos.color = Color.red;

            // Draw lines between the points to form a rectangle
            Gizmos.DrawLine(pos1, new Vector2(pos2.x, pos1.y)); // Top edge
            Gizmos.DrawLine(pos1, new Vector2(pos1.x, pos2.y)); // Left edge
            Gizmos.DrawLine(pos2, new Vector2(pos1.x, pos2.y)); // Bottom edge
            Gizmos.DrawLine(pos2, new Vector2(pos2.x, pos1.y)); // Right edge
            
        }
        
    }
}
