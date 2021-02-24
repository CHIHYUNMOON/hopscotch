using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    
    MapController _MapController;
    private int[] AILocationIndex;
    

    private void AIMove() {
        if (!_isYourTurn) {
            CheckTileCanMove();
          
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    private void CheckTileCanMove()
    {
        
    }
        
    private void Awake()
    {     
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        AILocationIndex = _MapController._AIFirstLocationIndex;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Invoke("AIMove", 2.0f);
    }
}
