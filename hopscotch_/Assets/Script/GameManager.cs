using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private  Character _player1;
    public Character _Player1 { get { return _player1; } set { _player1 = value; } }
    private Character _player2;
    public Character _Player2 { get { return _player2; } set { _player2 = value; } }
    private MapController _mapController;
   
    public static int _turnNumber=0;
    private static int _level = 1;

    private static bool _isPlayer1Turn = true;
    public static bool _IsPlayer1Turn  { get { return _isPlayer1Turn; } }

    private static bool _isPlayer2Turn = false;
    public static bool _IsPlayer2Turn { get { return _isPlayer2Turn; } }
    public static bool _isGameStart=false;


    public static int _Level  { get { return _level; } }



    private Tile _nextTile;
    public Tile _NextTile { get { return _nextTile; } set { _nextTile = value; } }


    IEnumerator TurnChanger()
    {
        while (true)
        {
            if (!_isGameStart)
                yield return null;
            else
            {
                if (_turnNumber == 0)
                {
                    //creat Player & AI
                    if (_isPlayer1Turn)
                    {
                        _mapController.CreateCharacter(_nextTile);
                    }
                    else if(!_isPlayer1Turn)
                    {
                        _mapController.CreateCharacter(null);
                        _turnNumber++; //Finish First turn
                    }                   
                    
                }

                else if (_turnNumber > 0)
                {
                    StartCoroutine(WaitUntilChooseTile());
                    if (_isPlayer1Turn &&_player1._isYouSelectTile)
                    {
                        //Player1 turn
                        _player1.CharacterMove(_nextTile);
                        _player1._isYouSelectTile = !_player1._isYouSelectTile;
                    }
                    else if (!_isPlayer1Turn && _player2._isYouSelectTile)
                    {
                        //Player2 Turn


                        _player2.CharacterMove(_nextTile);
                        _player2._isYouSelectTile = !_player2._isYouSelectTile;

                        _turnNumber++;
                    }
                    
                }
                _isPlayer1Turn = !_isPlayer1Turn;
                _isPlayer2Turn = !_isPlayer1Turn;

                yield return null;
            }
            yield return null;
        }          
            
    }




    IEnumerator WaitUntilChooseTile() {
        while (true) {
            if (_player1._isYouSelectTile ||_player2._isYouSelectTile)
                break;
            yield return null;
        }
        yield return null;

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
