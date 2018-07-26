using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public PlayerController player;
    public Transform playerTransform;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < (playerTransform.position.x-30))
        {            
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Object");
            collision.gameObject.GetComponent<PlayerController>().isDead = true;
            
        }
    }
    
}
