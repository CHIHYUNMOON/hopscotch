using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MapController mapController;
    public GameObject Player;
    public GameObject AIPlayer;
    public static int _turnNumber=0;

    private static int _level = 1;
    public static int _Level  { get { return _level; } }



    public void GetPlayers() {
        Player = GameObject.Find("Player(Clone)");
        AIPlayer = GameObject.Find("AIPlayer(Clone)");
    }
    
    public static void EndGame() {
         
    }

    void Awake()
    {
        
        
    }
   
  
}
