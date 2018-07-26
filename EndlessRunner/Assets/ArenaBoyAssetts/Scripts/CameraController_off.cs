using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera for the menu view, to save the view when the player dies
public class CameraController_off : MonoBehaviour {
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
        if (!player.isDead)
        {
            distanceToMove = player.transform.position.x - lastPlayerPosition.x;
            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
            lastPlayerPosition = player.transform.position;
        }
        else
        {
            //When the player dies, the offcamera will stop looking for him and stay at the same position. update method will be stoped.
            this.enabled = false;
        }
	}

    public void changePlayerAfterDeath()
    {

    }
}
