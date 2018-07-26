﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera for the menu view, to save the view when the player dies
public class CameraController : MonoBehaviour {
    public PlayerController player;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;

            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, player.transform.position.z - 20);

            lastPlayerPosition = player.transform.position;
     
	}

    public void changePlayerAfterDeath()
    {
        //Old one will be setActive false.
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }
}
