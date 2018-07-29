using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour {

    //Singleton Entwurfsmuster, nur eine Instanz darf bestehen.
    public static GlobalData Instance;

    void Awake()
    {
        if (Instance == null)
        {
            //Damit die Instanz dieser Klasse auch bei einem Szenenwechsel die gleiche bleibt. Direkt ab dem Menü am Anfang kann so die Globaldata in jeder Szene benutzt werden.
            Transform parentTransform = gameObject.transform;

            // If this object doesn't have a parent then its the root transform.
            while (parentTransform.parent != null)
            {
                // Keep going up the chain.
                parentTransform = parentTransform.parent;
            }
            GameObject.DontDestroyOnLoad(parentTransform.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

   
    }

    public GameObject button_restart;
    public GameObject button_quit;

    public PlayerController playerInstance;

    public TileManager tileManager;

    void Start()
    {
        playerInstance = FindObjectOfType<PlayerController>();
        button_restart = GameObject.FindWithTag("Button_Restart");
        button_quit = GameObject.FindWithTag("Button_Quit");
        tileManager = GameObject.FindWithTag("TileManager").GetComponent<TileManager>();
        button_restart.SetActive(false);
        button_quit.SetActive(false);
    }
  
}
