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
    

    private void Awake()
    {
        _score = UnityEngine.Random.Range(1, 6);
        _ScoreTextInst = Instantiate(_ScoreTextPrefab);
        _ScoreTextInst.transform.parent = gameObject.transform;
        TileText = _ScoreTextInst.GetComponent<TextMesh>();
        TileText.text = _score.ToString();  
        Renderer = GetComponent<Renderer>();
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        
        TileLocationIndex = new int[2];
    }

    private void BringCreatAI() {
        _mapController.CreateAI();
        GameManager._Player = MapController._playerInstance.GetComponent<Player>();
        GameManager._AIPlayer = MapController._aiInstance.GetComponent<AIPlayer>();
    }

    


    private void OnMouseDown()
    {
        
            if (GameManager._turnNumber == 0)
            {
                MapController._playerInstance = Instantiate(_mapController.PlayerPrefab);
                MapController._playerInstance.transform.position = this.transform.position + Vector3.up * 1.0f;
                GameManager._turnNumber++;
                Invoke("BringCreatAI", 1.0f);
            }
            else if (Player._Inst.CheckTileCanMove().Contains(this) && GameManager._turnNumber > 0) //Distance between tiles is about 1.0f
            {
                if (!_isOccupied)
                {
                    Player._Inst.CheckTileCanMove();
                    Player._Inst.CharacterMove(this);                    
                    GameManager._turnNumber++;
                    AIPlayer._Inst.CheckTileCanMove();
                    
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
        Player._isYourTurn = !Player._isYourTurn;
        GameManager.TurnCheck();
        
    }
}
