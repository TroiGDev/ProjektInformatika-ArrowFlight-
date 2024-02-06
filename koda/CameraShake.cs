using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shake;
    public AnimationCurve curve;
    public float duration;

    public GameObject followPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            shake = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += 1 * Time.deltaTime;

            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = new Vector3(followPoint.transform.position.x, followPoint.transform.position.y, startPos.z) + Random.insideUnitSphere * strenght;
            yield return null;
        }

        transform.position = new Vector3(followPoint.transform.position.x, followPoint.transform.position.y, startPos.z);
    }
}
