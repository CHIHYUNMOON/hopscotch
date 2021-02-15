using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int _score;
    public GameObject _ScoreText;
    public GameObject _player;
    Renderer Renderer;
    TextMesh TileText;
    Vector3 playerlocation;
    public bool _isOccupied = false;

    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreText = Instantiate(_ScoreText);
        _ScoreText.transform.parent =gameObject.transform;
        TileText = _ScoreText.GetComponent<TextMesh>();
        TileText.text = _score.ToString();
        Renderer = GetComponent<Renderer>();
        _player = GameObject.Find("Player");       
    }

    private void OnMouseDown()
    {
        if ((this.transform.position - _player.transform.position).sqrMagnitude <= 2.0f) //Distance between tiles is about 1.0f
        {
            if (!_isOccupied)
            {
                _player.transform.position = this.transform.position + Vector3.up * 0.5f;
            }
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") ) {
            
            _isOccupied = true;
            
            Renderer.material.color = Color.red;
        }
        if (other.gameObject.CompareTag("AIPlayer")) {
            _isOccupied = true;
            Renderer.material.color = Color.blue;
        }
    }
    
    void Start()
    {
        
       
    }

    
    void Update()
    {
        
    }
}
