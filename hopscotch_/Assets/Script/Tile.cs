using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int _score;
    public GameObject _ScoreText;
    public Player _player;
    Renderer Renderer;
    TextMesh TileText;

    public bool _isOccupied = false;

    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreText = Instantiate(_ScoreText);
        _ScoreText.transform.parent =gameObject.transform;
        TileText = _ScoreText.GetComponent<TextMesh>();
        TileText.text = _score.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") ) {
            
            _isOccupied = true;
        }
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
