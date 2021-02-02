using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int _score;
    public Color[] _tileColor;
    Renderer _tileRenderer;
    
    Tile(Vector3 Tilelocation) {
       /* _score = UnityEngine.Random.Range(1, 6);
        transform.position = Tilelocation;
        _tileRenderer = gameObject.GetComponent<Renderer>();
        _tileRenderer.material.color = _tileColor[UnityEngine.Random.Range(0, 3)];*/
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = UnityEngine.Random.Range(1, 6);
        //transform.position = Tilelocation;
        _tileRenderer = gameObject.GetComponent<Renderer>();
       _tileRenderer.material.color = _tileColor[UnityEngine.Random.Range(0, 3)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
