using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {
   public GameObject firstGameInstance;
   public GameObject secondGameInstance;

    public GameObject arenaBoy1;
    public GameObject arenaBoy2;

    public DistanceCount distanceCounter;

    public TileManager tileManager;

    //0 first, 1 second game instance in use.
    public int firstOrSecond;

    void Awake()
    {
        firstGameInstance = GameObject.Find("FirstGameInstance");
        secondGameInstance = GameObject.Find("SecondGameInstance");
        distanceCounter = GameObject.Find("DistanceCount").GetComponent<DistanceCount>();
        tileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
        arenaBoy1 = firstGameInstance.transform.Find("Scripts/ArenaBoy").gameObject;
        arenaBoy2 = secondGameInstance.transform.Find("Scripts/ArenaBoy").gameObject;
    }

    // Use this for initialization
    void Start () {
        secondGameInstance.SetActive(false);
        firstOrSecond = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openSecondGameInstance()
    {
        secondGameInstance.SetActive(true);
        firstOrSecond = 1;
        revivePlayer(secondGameInstance);
        tileManager.changeArenaBoy(arenaBoy2.transform);
        distanceCounter.resetCount();
    }

    public void openFirstGameInstance()
    {
        firstGameInstance.SetActive(true);
        firstOrSecond = 0;
        revivePlayer(firstGameInstance);
        tileManager.changeArenaBoy(arenaBoy1.transform);
        distanceCounter.resetCount();
    }

    public void revivePlayer(GameObject gameInstance)
    {
        PlayerController pc = gameInstance.transform.Find("Scripts/ArenaBoy").GetComponent<PlayerController>();
        pc.enabled = true;
        pc.revive();
    }
  
}
