﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _score;
    public GameObject _ScoreText;
    TextMesh TileText;
    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreText = Instantiate(_ScoreText);
        _ScoreText.transform.parent =gameObject.transform;
        TileText = _ScoreText.GetComponent<TextMesh>();
        TileText.text = _score.ToString();
    }

    private void Occupied() {

        
    }
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
