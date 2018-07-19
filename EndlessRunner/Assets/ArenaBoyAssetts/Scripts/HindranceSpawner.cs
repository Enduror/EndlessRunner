using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindranceSpawner : MonoBehaviour {

    private Transform playerTransform;
    private Transform tileManagerTransform;
    public GameObject[] tilePrefabs;

    public int distanceBetween;
    public float hindranceHight;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = playerTransform.position + new Vector3(20, 0);
        tileManagerTransform = FindObjectOfType<TileManager>().GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < playerTransform.position.x + 15)
        {
            spawnBox();
            transform.position = transform.position + new Vector3(distanceBetween,0,0);            
        }
	}
    public void spawnBox()
    {
        distanceBetween = Random.Range(5, 15);
        hindranceHight = Random.Range(-2, -4);
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(tileManagerTransform);
        go.transform.position = new Vector3(transform.position.x, hindranceHight,0);
    }
}
