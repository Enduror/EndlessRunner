﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public PlayerController player;
    public Transform playerTransform;
    
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < (playerTransform.position.x-10))
        {            
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player.isDead = true;
           
            
        }
    }
    
}
