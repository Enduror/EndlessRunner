using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public List<GameObject> activeTiles;
    public Animator anim;

    private Transform playerTransform;
    private Transform objectSpawnPoint;

    private Vector2 StartStreet;


    private float spawnX =-15f;
    private float tileLenght = 1;
    private int amountTilesOnScreen = 40;

  

	// Use this for initialization
	void Start () {                   
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = playerTransform.GetComponent<Animator>();

        InstantiateGround();        
	}
	
	// Update is called once per frame
	void Update () {        
		if ( playerTransform.position.x  > (spawnX - amountTilesOnScreen * tileLenght)){
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
        go.transform.position = new Vector2(-5,-3.75f) + new Vector2(1,0)* spawnX;
        spawnX += tileLenght;
        activeTiles.Add(go);

        // Spawns an underground TIle

    }
    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void InstantiateGround()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < amountTilesOnScreen; i++)
        {
            if (anim.GetBool("isSleeping") == true)
            {
                spawnX = -20;
            }
            SpawnTile();
        }
    }
   
}
