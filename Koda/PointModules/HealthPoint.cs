using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public int index;

    private HealthManager hlthMngr;
    private Image sr;

    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        hlthMngr = (HealthManager)FindObjectOfType(typeof (HealthManager));
        sr = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hlthMngr.healthPoints >= index)
        {
            sr.sprite = sprites[0];
        }
        else
        {
            sr.sprite = sprites[1];
        }
    }
}
