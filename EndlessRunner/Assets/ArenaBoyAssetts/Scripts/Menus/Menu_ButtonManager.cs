using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_ButtonManager : MonoBehaviour {
    public PlayerController player;
    public PlatFormGen generator;
    public Transform startPosition;
    public GameObject menu_interface;
    public Animator playerAnim;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Button_Restart()
    {
        player.transform.position = startPosition.position;
        generator.transform.position = startPosition.position;
        player.isDead = false;
        menu_interface.SetActive(false);
       
        player.ResetPlayer();
    }
}
