using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatFormGen : MonoBehaviour {




    [SerializeField]
    public GameObject player;
    public Transform generator;
    public Transform deleter;
    public Transform platformHolder;

    public int allowedPlatforms;

   
    public float platformLength;
    public float abstand;


    public int ChargeLevel;
    public float JumpHight;



    public GameObject tilePrefabs;
    public List<GameObject> activeTiles;

   
   





    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

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
        
	}


    public void SpawnPlatform()
    {
        GameObject go;
        go = Instantiate(tilePrefabs) as GameObject;
        go.transform.SetParent(platformHolder);

        go.transform.position = generator.position;
        generator.position+= new Vector3( abstand + platformLength,  ChargeLevel*JumpHight, 0);
        activeTiles.Add(go);
    }
    public void DeletePlatform()
    {
        if (activeTiles.Count > 10)
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }

    }
}
