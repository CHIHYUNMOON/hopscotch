using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    


    public void AIMove()
    {
        List<Tile> Check = CheckTileCanMove();
        Tile NextTile = null;
        int MaxScore = 0;

        foreach (Tile T in Check)
        {
            if (!T._isOccupied)
            {
                if (T._score > MaxScore)
                {
                    MaxScore = T._score;
                    NextTile = T;
                }
            }
        }
        if (Check == null)
        {
            GameManager.EndGame();
        }
        else
        {
            this.transform.position = NextTile.transform.position + Vector3.up * 1.0f;
            PlayerLocationIndex = NextTile.TileLocationIndex;
        }
        
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }



    private void Awake()
    {
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        PlayerLocationIndex = _MapController._AIFirstLocationIndex;
    }

}