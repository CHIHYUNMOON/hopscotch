using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int _score;
    public GameObject _ScoreText;
    public GameObject _player;
    private GameManager _gameManager;
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
        
        
    }
    
    private void OnMouseDown()
    {
        if (GameManager._turnNumber == 0) {
            _player = Instantiate(_player);
            _player.transform.position = this.transform.position + Vector3.up * 1.0f;
            GameManager._turnNumber++;
        }
        else if ((this.transform.position - _player.GetComponent<Player>()._Tile.transform.position).sqrMagnitude <= 2.0f && GameManager._turnNumber>0) //Distance between tiles is about 1.0f
        {
            if (!_isOccupied)
            {
                _player.transform.position = this.transform.position + Vector3.up * 0.5f;
                GameManager._turnNumber++;
            }
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") ) {
            Renderer.material.color = Color.red;
        }
        if (other.gameObject.CompareTag("AIPlayer")) {            
            Renderer.material.color = Color.blue;
        }

        _isOccupied = true;
    }
    
    void Start()
    {
        
       
    }

    
    void Update()
    {
        
    }
}
