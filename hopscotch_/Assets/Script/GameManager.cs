using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player _Player;
    public static AIPlayer _AIPlayer;
    public MapController mapController;
   
    public static int _turnNumber=0;

    private static int _level = 1;
    public static int _Level  { get { return _level; } }

   


   

    public static void TurnCheck() {
        if (_turnNumber > 1)
        {
            if (_turnNumber % 2 == 0)
            {
                _AIPlayer.CheckTileCanMove();
            }
            else if (_turnNumber % 2 == 1)
            {
                _Player.CheckTileCanMove();
            }
        }
    }
    public static void EndGame()
    {
        Debug.Log("the End");
        if (Player._isYourTurn)
        {
            Debug.Log("AI +10");
            _AIPlayer._playerScore += 10;
        }
        else if (!Player._isYourTurn)
        {
            Debug.Log("Player +10");
            _Player._playerScore += 10;
        }

        if (_AIPlayer._playerScore > _Player._playerScore)
        {
            Debug.Log("AI Win");
        }
        else if (_AIPlayer._playerScore < _Player._playerScore)
        {
            Debug.Log("Player Win");
        }
        else if (_AIPlayer._playerScore == _Player._playerScore)
        {
            Debug.Log("Draw");
        }
    }

    void Awake()
    {
        
        
    }
   
  
}
