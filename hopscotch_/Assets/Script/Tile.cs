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
    private MapController _mapController;
    private AIPlayer aIPlayer;
    public int[] TileLocationIndex;
    

    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreText = Instantiate(_ScoreText);
        _ScoreText.transform.parent =gameObject.transform;
        TileText = _ScoreText.GetComponent<TextMesh>();
        TileText.text = _score.ToString();  
        Renderer = GetComponent<Renderer>();
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        TileLocationIndex = new int[2];
    }

    private void BringCreatAI() {
        _mapController.CreateAI();
    }
    private void BringAIMove() {
        aIPlayer.AIMove();
    }
    private void OnMouseDown()
    {
        if (Player._isYourTurn)
        {
            if (GameManager._turnNumber == 0)
            {
                _player = Instantiate(_player);
                _player.transform.position = this.transform.position + Vector3.up * 1.0f;

                Invoke("BringCreatAI", 0.5f);
            }
            else if ((this.transform.position - Player._Inst._Tile.transform.position).sqrMagnitude <= 2.0f && GameManager._turnNumber > 0) //Distance between tiles is about 1.0f
            {
                if (!_isOccupied)
                {
                    Player._Inst.transform.position = this.transform.position + Vector3.up * 1.0f;
                    aIPlayer = GameObject.Find("AIPlayer(Clone)").GetComponent<AIPlayer>();
                    Invoke("BringAIMove", 1.0f);
                }
            }
        }
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
        Player._isYourTurn = !Player._isYourTurn;
        GameManager._turnNumber++;
    }
}
