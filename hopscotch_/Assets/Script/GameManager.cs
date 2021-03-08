using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MapController mapController;
   
    public static int _turnNumber=0;

    private static int _level = 1;
    public static int _Level  { get { return _level; } }



   

    public void TurnCheck() {
        if (_turnNumber % 2 == 0)
        {
            
        }
        else if (_turnNumber % 2 == 1)
        {

        }
    }
    public static void EndGame() {
        Debug.Log("the End");
        if (Player._isYourTurn)
        {
            Debug.Log("AI +10");
            GameObject.Find("AIPlayer(Clone)").GetComponent<AIPlayer>()._playerScore += 10;
        }
        else if (!Player._isYourTurn) {
            Debug.Log("Player +10");
            GameObject.Find("Player(Clone)").GetComponent<Player>()._playerScore += 10;
        }

        if (GameObject.Find("AIPlayer(Clone)").GetComponent<AIPlayer>()._playerScore > GameObject.Find("Player(Clone)").GetComponent<Player>()._playerScore)
        {
            Debug.Log("AI Win");
        }
        else if (GameObject.Find("AIPlayer(Clone)").GetComponent<AIPlayer>()._playerScore < GameObject.Find("Player(Clone)").GetComponent<Player>()._playerScore)
        {
            Debug.Log("Player Win");
        }
        else if (GameObject.Find("AIPlayer(Clone)").GetComponent<AIPlayer>()._playerScore == GameObject.Find("Player(Clone)").GetComponent<Player>()._playerScore) {
            Debug.Log("Draw");
        }
    }

    void Awake()
    {
        
        
    }
   
  
}
