using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{


    public PlatFormGen generator;
    public TextMesh text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
        generator = FindObjectOfType<PlatFormGen>();
        text.text = generator.holeCounter.ToString();

    }
}
    
