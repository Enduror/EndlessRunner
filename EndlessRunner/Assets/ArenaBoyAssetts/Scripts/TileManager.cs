using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public List<GameObject> activeTiles;   

    private Transform playerTransform;
    private Transform objectSpawnPoint;

    private Vector2 StartStreet;

    GlobalData globalData;

    private float spawnX = 0.0f;
    private float tileLenght = 1;
    private int amountTilesOnScreen =20;

    private void Awake()
    {
        globalData = GameObject.FindWithTag("GlobalData").GetComponent<GlobalData>();
    }

    // Use this for initialization
    void Start () {
        playerTransform = globalData.arenaBoy1.transform;
        createFirstTiles();
	}

    public void createFirstTiles()
    {
        activeTiles = new List<GameObject>();

        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }

    }

     public void deleteAllTiles()
    {
        spawnX = 0.0f;
        foreach (GameObject tile in activeTiles)
        {           
            Destroy(tile);
        }
    }

    public void changeArenaBoy(Transform t)
    {
        playerTransform = t;
        deleteAllTiles();
        createFirstTiles();
    }
	
	// Update is called once per frame
	void Update () {    
		if(playerTransform.position.x  > (spawnX - amountTilesOnScreen * tileLenght)){
            SpawnTile();
            DeleteTile();
        }    
	}

    public void SpawnTile()
    {
        //Depending on which level is instantiated
        int zOffset;

        if (globalData.firstOrSecond == 0)
        {
            zOffset = 0;
        }
        else
        {
            zOffset = 230;
        }
        // spawns a TIle
        GameObject go;        
        go = Instantiate(tilePrefabs[0]) as GameObject;      
        go.transform.SetParent(transform);        
        go.transform.position = new Vector3(-5,-3.9f, -zOffset) + new Vector3(1,0)* spawnX;
        spawnX += tileLenght;
        activeTiles.Add(go);

        // Spawns an underground TIle

    }
    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
   
}
