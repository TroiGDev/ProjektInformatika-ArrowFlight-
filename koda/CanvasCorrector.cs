using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCorrector : MonoBehaviour
{
    public bool isMobile;

    public Vector3 pcPosition;
    public Vector3 mobilePosition;

    //public string type;             calibration string type can be whateevr 

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //rectTransform.anchoredPosition = new Vector2(x, y);

        if (Application.isMobilePlatform)
        {isMobile = true;}else{isMobile = false;}

        if(isMobile)
        {
            rectTransform.anchoredPosition = mobilePosition;
        }
        if (!isMobile)
        {
            rectTransform.anchoredPosition = pcPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //calibration setup:
        //RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //string x = type + rectTransform.anchoredPosition.ToString();
        //Debug.Log(x);
    }
}
