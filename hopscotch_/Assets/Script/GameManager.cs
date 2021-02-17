using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MapController mapController;
    public GameObject Player;
    public GameObject AIPlayer;

    private int _level = 1;
    public static int _turnNumber = 0;
    private int _numberOfPlayer = 2;

    
    public void ChangeTurn() {
        int checkPlayerBehavior = 1;
        while (checkPlayerBehavior < _numberOfPlayer) {
            checkPlayerBehavior++;
        }
        _turnNumber++;
    }

    void Awake()
    {
        
        
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
