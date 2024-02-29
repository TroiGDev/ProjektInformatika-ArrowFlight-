using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaButton : MonoBehaviour
{
    public LockedAreas lckMngr;

    public int index;

    public string openString;
    public string closedString;
    public float cost;
    public bool IsOpen;

    public TextMeshProUGUI button_txt;
    public TextMeshProUGUI button_txt_shadow;

    [Header("sfx")]
    public AudioSource bought_src;
    public AudioClip bought_sfx;

    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        lckMngr = (LockedAreas)FindObjectOfType(typeof (LockedAreas));
        score = (Score)FindObjectOfType(typeof (Score));
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1)
        {
            if (IsOpen)
            {
                lckMngr.Area1Open = true;
            }

            if (lckMngr.Area1Open)
            {
                button_txt.text = openString;
                button_txt_shadow.text = openString;
                IsOpen = true;
            }
            else if (!lckMngr.Area1Open)
            {
                button_txt.text = closedString + cost.ToString();
                button_txt_shadow.text = closedString + cost.ToString();
                IsOpen = false;
            }
        }

        if (index == 2)
        {
            if (IsOpen)
            {
                lckMngr.Area2Open = true;
            }

            if (lckMngr.Area2Open)
            {
                button_txt.text = openString;
                button_txt_shadow.text = openString;
                IsOpen = true;
            }
            else if (!lckMngr.Area2Open)
            {
                button_txt.text = closedString + cost.ToString();
                button_txt_shadow.text = closedString + cost.ToString();
                IsOpen = false;
            }
        }

        if (index == 3)
        {
            if (IsOpen)
            {
                lckMngr.Area3Open = true;
            }

            if (lckMngr.Area3Open)
            {
                button_txt.text = openString;
                button_txt_shadow.text = openString;
                IsOpen = true;
            }
            else if (!lckMngr.Area3Open)
            {
                button_txt.text = closedString + cost.ToString();
                button_txt_shadow.text = closedString + cost.ToString();
                IsOpen = false;
            }
        }
    }

    public void getsPressed()
    {
        if (!IsOpen)
        {
            if (score.money >= cost)
            {
                IsOpen = true;
                score.money -= cost;
                bought_src.PlayOneShot(bought_sfx, 1f);
            }
        }
    }
}
