using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{

    MapController _MapController;
    private int[] AILocationIndex; //= {3,2}


    public void AIMove()
    {

        CheckTileCanMove();


    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    private void CheckTileCanMove()
    {
        List<Tile> Check = new List<Tile>();
        Tile NextTile = null;
        int MaxScore = 0;
        if (AILocationIndex[0] - 1 > 0 && AILocationIndex[0] + 1 < _MapController._MapSize.Length && AILocationIndex[1] - 1 > 0 && AILocationIndex[1]+1 < _MapController._MapSize[AILocationIndex[0]])
        {
            if (_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1] - 1] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]].GetComponent<Tile>());
            }
            if (_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] - 1] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] + 1] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1] - 1] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1]] != null)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
        }

        //----------------------------------------------------------------------------------
        foreach (Tile T in Check)
        {
            if (T._score > MaxScore)
            {
                MaxScore = T._score;
                NextTile = T;
            }

        }
        this.transform.position = NextTile.transform.position;
    }

    private void Awake()
    {
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        AILocationIndex = _MapController._AIFirstLocationIndex;
    }

}