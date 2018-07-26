using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        GlobalData.playerInstance.isDead = false;
        GlobalData.playerInstance.enabled = true;
        GlobalData.Instance.button_restart.SetActive(false);
        GlobalData.Instance.button_quit.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
