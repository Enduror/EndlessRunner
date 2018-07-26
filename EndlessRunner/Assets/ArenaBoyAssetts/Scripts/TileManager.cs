using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public List<GameObject> activeTiles;   

    private Transform playerTransform;
    private Transform objectSpawnPoint;

    private Vector2 StartStreet;


    private float spawnX = 0.0f;
    private float tileLenght = 1;
    private int amountTilesOnScreen =20;

  

	// Use this for initialization
	void Start () {       
        activeTiles = new List<GameObject>();       
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       

        for(int i=0; i<20; i++)
        {           
            SpawnTile();           
        }
        
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

        // spawns a TIle
        GameObject go;        
        go = Instantiate(tilePrefabs[0]) as GameObject;      
        go.transform.SetParent(transform);        
        go.transform.position = new Vector2(-5,-3.9f) + new Vector2(1,0)* spawnX;
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
