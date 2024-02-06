using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPoint : MonoBehaviour
{
    private HealthManager hltMngr;

    [Header("indexing")]
    public float index;
    private bool IsFull;

    [Header("visual")]
    private SpriteRenderer sr;
    private Color activeColor;
    private Color strtColor;
    // Start is called before the first frame update
    void Start()
    {
        if (hltMngr == null)
        {hltMngr = (HealthManager)FindObjectOfType(typeof (HealthManager));}
    
        sr = gameObject.GetComponent<SpriteRenderer>();

        strtColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (hltMngr.ammo >= index)
        {IsFull = true;} else {IsFull = false;}


        if (IsFull)
        {
            sr.color = strtColor;
        }

        if (!IsFull)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
        }
    }
}
