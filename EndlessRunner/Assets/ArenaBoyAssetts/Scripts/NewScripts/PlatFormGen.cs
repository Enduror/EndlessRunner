using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Heiho Lars! 

    //hier das Problem. ichv ersuche nicht platformen zu erzeugen sondern " löcher" als leere platformen
    //dafür muss es funktionieren das alle platformen immer nacheinaner spawnen erreihen möchte ich das indem man immer die neue und die nächste Platform vergleicht deren boxcollider zusammenrechner und durch 2 Teilt
    // um den abstand zwischen den beiden Spawn punkten zu erhalten. Diese berechnung soll für jede Platform stattfinden egal ob loch oder nicht
    //leider funktioniet das nur wenn man die selben platformen hintereinander benutzt. (oder zumidnest gleich lange)   Ich will aber das das variables geht
    // damit wir später au die löscher ect variable verwenden können. 
    // kannste mal drüber schauen woran das liegt?


public class PlatFormGen : MonoBehaviour {




    [SerializeField]
    public GameObject player;
    public Transform generator;
    public Transform deleter;
    public Transform platformHolder;

    public bool isLastElemHole;

    public int holeCounter;

    public int allowedPlatforms;

   
    public float platformLength;
    public float abstand;


    public int ChargeLevel;
    public float JumpHight;

    public float playerSpeed;
    public float startSpeed;

    private int randomNumber;
    




    public GameObject[] tilePrefabs;
    public GameObject lastPrefab;
    public List<GameObject> activeTiles;
 

    

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpeed = player.GetComponent<PlayerController>().playerSpeed;
        startSpeed = playerSpeed;
        lastPrefab = null;
        holeCounter = 0;


        

        // platformlength ist die hälfte des Colliders der Platform falls man etwas direct ansetzen möchte. // FUnktioniert aber merkwürdig

       // platformLength = (tilePrefabs.GetComponentInChildren<BoxCollider2D>().size.x)/2;

       
        
    }

	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x+100 >= generator.position.x)
        {
            SpawnPlatform();
            DeletePlatform();
        }



        // test Input
        if (Input.GetKeyDown(KeyCode.T))
        {
           
        }
        
	}


    public void SpawnPlatform()
    {

        // keine löcher am anfang
        if (generator.transform.position.x<= 15)
        {
            randomNumber = 1;
        }
        else
        {
            
            randomNumber = Random.Range(0, tilePrefabs.Length);
            // 0==hole
            if (randomNumber == 0)
            {
                holeCounter++;
                Debug.Log(holeCounter);
            }
            else
            {
                holeCounter = 0;
            }
            if (holeCounter > 3)
            {
                Debug.Log("4rerLoch verhindert");
                randomNumber= Random.Range(1, tilePrefabs.Length);
                Random.Range(0, tilePrefabs.Length);
            }
            
        }       
        
           
        
        
       



        // Neues Gameobject wird in der hierarchy erstellt, dem platformHolder zugewiesen und anschließend an die letzte Platform angereiht.


        GameObject go;
        go = Instantiate(tilePrefabs[randomNumber]) as GameObject;
        go.transform.SetParent(platformHolder);
        
        activeTiles.Add(go);

        if (activeTiles.Count >=2) {           
            abstand = (activeTiles[activeTiles.Count - 2].GetComponent<BoxCollider2D>().size.x + activeTiles[activeTiles.Count-1].GetComponent<BoxCollider2D>().size.x) / 2;            
        }
        else
        {
            abstand =0;
        }
        // platform wird immer an die position des generators gepackt

        generator.position += new Vector3(abstand, ChargeLevel * JumpHight, 0);
        go.transform.position = generator.position;



    }
    public void DeletePlatform()
    {
        if (activeTiles.Count > allowedPlatforms && player.transform.position.x-20>= activeTiles[0].transform.position.x)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

    }   


}
