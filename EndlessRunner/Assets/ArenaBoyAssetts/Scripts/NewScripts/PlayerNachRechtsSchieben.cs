using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNachRechtsSchieben : MonoBehaviour {
    public Transform startPunkt;
    public float playerVelocity;
   

    public Vector3 velocity;
	// Use this for initialization
	void Start () {
        transform.position = startPunkt.position;
       
        velocity = new Vector3(playerVelocity, 0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {        
        transform.position += velocity * Time.deltaTime;        
	}
}
