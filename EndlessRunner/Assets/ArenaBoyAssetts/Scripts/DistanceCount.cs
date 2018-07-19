using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCount : MonoBehaviour {
    public float distanceRun;
    public float startPosition;
    public float currentPlayerPosition;

    public Text score;

    public Transform playerTransform;
   
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPosition = playerTransform.position.x;
        score = GetComponent<Text>();
        
        distanceRun = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentPlayerPosition = playerTransform.position.x;
        distanceRun = startPosition - currentPlayerPosition;
        score.text= Mathf.Round(Mathf.Abs(distanceRun)).ToString();
    }
}
