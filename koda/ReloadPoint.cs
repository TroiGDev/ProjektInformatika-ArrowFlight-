using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPoint : MonoBehaviour
{
    private HealthManager hltMngr;

    private float currTime;

    private float strtScalex;
    private float scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        if (hltMngr == null)
        {hltMngr = (HealthManager)FindObjectOfType(typeof (HealthManager));}
    
        strtScalex = transform.localScale.x;

        transform.localScale = new Vector3(0f, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        currTime = hltMngr.currReloadTime;

        if (hltMngr.maxReloadTime > 0)
        {scaleFactor = currTime / hltMngr.maxReloadTime;}  //gives a scale from 0 to 1
        else
        {scaleFactor = 0f;}

        transform.localScale = new Vector3(strtScalex * scaleFactor, transform.localScale.y, transform.localScale.z);
    }
}
