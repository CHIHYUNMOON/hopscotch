using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player _Player;
    public static AIPlayer _AIPlayer;
    private MapController _mapController;
   
    public static int _turnNumber=0;
    private static int _level = 1;

    private bool _isPlayer1Turn = true;
    public bool _IsPlayer1Turn  { get { return _isPlayer1Turn; } }

    private bool _isPlayer2Turn = false;
    public bool _IsPlayer2Turn { get { return _isPlayer2Turn; } }
    public static bool _isGameStart=false;


    public static int _Level  { get { return _level; } }



    private Tile _nextTile;
    public Tile _NextTile { get { return _nextTile; } set { _nextTile = value; } }


    IEnumerator TurnChanger()
    {
        yield return WaitUntil.
        while (_isGameStart)
        {
            if (_turnNumber == 0)
            {
                //creat Player & AI
                if (_isPlayer1Turn)
                {
                    _mapController.CreateCharacter(_nextTile);
                }

            }
            else if (_turnNumber > 0 && _isPlayer1Turn)
            {
                //Player turn
            }
            else if (_turnNumber > 0 && _isPlayer2Turn)
            {
                //AI Turn
            }
            _isPlayer1Turn = !_isPlayer1Turn;
            _isPlayer2Turn = !_isPlayer1Turn;
        }

        yield return null;
    }
   
    
    public static void TurnCheck() {
        if (_turnNumber > 1)
        {
            if (_turnNumber % 2 == 0)
            {
                _AIPlayer.CheckTileCanMove();
                _Player.CheckTileCanMove();
            }
            else if (_turnNumber % 2 == 1)
            {
                _Player.CheckTileCanMove();
            }
        }
    }

    //public static void EndGame()
    //{
    //    Debug.Log("the End");
    //    if (Player._isYourTurn)
    //    {
    //        Debug.Log("AI +10");
    //        _AIPlayer.PlayerScore += 10;
    //    }
    //    else if (!Player._isYourTurn)
    //    {
    //        Debug.Log("Player +10");
    //        _Player.PlayerScore += 10;
    //    }

    //    if (_AIPlayer.PlayerScore > _Player.PlayerScore)
    //    {
    //        Debug.Log("AI Win");
    //    }
    //    else if (_AIPlayer.PlayerScore < _Player.PlayerScore)
    //    {
    //        Debug.Log("Player Win");
    //    }
    //    else if (_AIPlayer.PlayerScore == _Player.PlayerScore)
    //    {
    //        Debug.Log("Draw");
    //    }
    //}

    void Awake()
    {
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        
    }
    private void Start()
    {
        StartCoroutine(TurnChanger());
    }
    private void Update()
    {
        //if (_isGameStart) {
        //    StartCoroutine(TurnChanger());
        //}
    }
}
