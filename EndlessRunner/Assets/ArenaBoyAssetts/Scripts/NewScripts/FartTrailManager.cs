using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartTrailManager : MonoBehaviour
{
    public ParticleSystem particleEffect;
    public Vector2 lastPlayerPosition;
    public Vector2 currentPlayerPosition;
    public Vector2 direction;
    public PlayerController player;  


    public float timer=1;

    // Use this for initialization
    void Start()
    {
        particleEffect = GetComponent<ParticleSystem>();
        player = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {   

        RotateFart();
    }

    public void RotateFart()
    {
        timer -= Time.deltaTime;
        if (timer > 0.1f)
        {
            lastPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
           
            
        }
        if (timer <= 0)
        {
            currentPlayerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            timer = 0.2f;
        }


       

        
        direction = currentPlayerPosition - lastPlayerPosition;
       



        transform.rotation = Quaternion.LookRotation(direction);

       

        //float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Debug.Log(rotZ);
        //transform.rotation = Quaternion.Euler(rotZ, 0, 0);

    }
 

}
