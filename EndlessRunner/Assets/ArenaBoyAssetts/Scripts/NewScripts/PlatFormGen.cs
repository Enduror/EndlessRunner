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
    public List<GameObject> abstand2Tiles;








    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpeed = player.GetComponent<PlayerController>().playerSpeed;
        startSpeed = playerSpeed;
        lastPrefab = null;


        

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            TestHole();
        }
        
	}


    public void SpawnPlatform()
    {
                
        randomNumber = Random.Range(0, tilePrefabs.Length);
       
         
      

        GameObject go;
        go = Instantiate(tilePrefabs[randomNumber]) as GameObject;
        go.transform.SetParent(platformHolder);
        go.transform.position = generator.position;
        
       
      //  abstand = go.GetComponent<BoxCollider2D>().size.x/2 + activeTiles[activeTiles.Count-1].GetComponent<BoxCollider2D>().size.x/2;      


        generator.position += new Vector3(AbstandCalculator(go),    ChargeLevel * JumpHight, 0);
        
        activeTiles.Add(go);
       
    }
    public void DeletePlatform()
    {
        if (activeTiles.Count > allowedPlatforms && player.transform.position.x-20>= activeTiles[0].transform.position.x)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

    }


    public void TestHole()
    {
       for(int i = 0; i < abstand2Tiles.Count; i++)
        {
            i++;
            Debug.Log(i);
        }
        
    }


    public float AbstandCalculator(GameObject tile)
    {
        abstand2Tiles.Add(tile);
        if (abstand2Tiles.Count>2)
        {
            abstand2Tiles.RemoveAt(0);
            abstand = (abstand2Tiles[0].GetComponent<BoxCollider2D>().size.x + abstand2Tiles[1].GetComponent<BoxCollider2D>().size.x) / 2;
           
        }     
                
                
       

        return abstand;
    }
}
