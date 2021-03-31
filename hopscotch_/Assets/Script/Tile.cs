using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int _score;
    public int Score { get { return _score; } }
    [SerializeField]
    private GameObject _ScoreTextPrefab;
    private GameObject _ScoreTextInst;
    
    Renderer Renderer;
    TextMesh TileText;
   
    public bool _isOccupied = false;
    private MapController _mapController;
    private AIPlayer aIPlayer;
    public int[] TileLocationIndex;
    public GameManager _gameManager;

    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreTextInst = Instantiate(_ScoreTextPrefab);
        _ScoreTextInst.transform.parent = gameObject.transform;
        TileText = _ScoreTextInst.GetComponent<TextMesh>();
        TileText.text = _score.ToString();  
        Renderer = GetComponent<Renderer>();
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TileLocationIndex = new int[2];

    }

   

    


    private void OnMouseDown()
    {      
            if (GameManager._turnNumber == 0)
            {
                GameManager._isGameStart = true;                
                _gameManager._NextTile = this;               
            }
            else if (_gameManager._Player1.CheckTileCanMove().Contains(this) && GameManager._IsPlayer1Turn) //Distance between tiles is about 1.0f
            {
                if (!_isOccupied)
                {                  
                    _gameManager._NextTile = this;
                    _gameManager._Player1._isYouSelectTile = true;
                }
            }
            else if (_gameManager._Player2.CheckTileCanMove().Contains(this) && GameManager._IsPlayer2Turn) //Distance between tiles is about 1.0f
            {
                if (!_isOccupied)
                {
                    _gameManager._NextTile = this;
                    _gameManager._Player2._isYouSelectTile = true;
                }
            }

        Debug.Log(GameManager._turnNumber.ToString());      
    }



    private void OnCollisionEnter(Collision other)
    {
        if (!_isOccupied)
        {
            if (other.gameObject.CompareTag("Player"))
            {   
                Renderer.material.color = Color.red;
            }
            if (other.gameObject.CompareTag("AIPlayer"))
            {
                Renderer.material.color = Color.blue;                
            }
            _isOccupied = true;
        }
        
        
        
    }
}
