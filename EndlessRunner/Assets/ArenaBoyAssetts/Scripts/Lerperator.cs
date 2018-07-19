using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerperator : MonoBehaviour
{


    float lerpTime = 1f;
    float currentLerpTime;

    Vector2 startPos;
    Vector2 endPos;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(transform.position.x + 0.5f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLerpTime = 0f;
        }

        //increment timer once per frame
        currentLerpTime += Time.deltaTime;

        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        //lerp!
        float t = currentLerpTime / lerpTime;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);


        transform.position = Vector2.Lerp(startPos, endPos, t);
    }
}
    


