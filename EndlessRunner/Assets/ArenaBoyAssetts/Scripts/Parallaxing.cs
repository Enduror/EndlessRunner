using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {


    public float backgroundSize;
    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 5;
    private int leftIndex;
    private int rightIndex;

    public float parallaxSpeed;
    private float lastCameraX;

    private void Start()
    {
        


        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
          
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }



    private void Update()
    {

        float deltaX = cameraTransform.position.x - lastCameraX;

        transform.position += new Vector3(deltaX * parallaxSpeed, 0, 0);

        lastCameraX = cameraTransform.position.x;


        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            ScroolRight();
        }
    }

    private void ScroolRight()
    {
        int lastLeft = leftIndex;
       
        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, transform.position.y, transform.position.z);
        
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex== layers.Length){
            leftIndex = 0;
        }
    }


}
