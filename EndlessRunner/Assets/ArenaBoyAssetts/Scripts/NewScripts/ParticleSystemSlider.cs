using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemSlider : MonoBehaviour {
    public Transform perfectPoint1;
    public Transform perfectPoint2;
    public Transform perfectPoint3;
    public int ParticleIndex;

    // Use this for initialization
   
    private void Update()
    {
        if (ParticleIndex == 1)
        {
            transform.position = perfectPoint1.position;

        }
        if (ParticleIndex == 2)
        {
            transform.position = perfectPoint2.position;

        }
        if (ParticleIndex == 3)
        {
            transform.position = perfectPoint3.position;

        }
    }

}
