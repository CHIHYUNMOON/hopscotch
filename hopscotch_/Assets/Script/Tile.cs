using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int _score;

    Tile(Vector3 Tilelocation) {
        _score = UnityEngine.Random.Range(1, 6);
        transform.position = Tilelocation;


    }

    // Start is called before the first frame update
    void Start()
    {
        _score = UnityEngine.Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
