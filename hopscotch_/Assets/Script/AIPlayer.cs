using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{

    MapController _MapController;
    private int[] AILocationIndex; //


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
        if (AILocationIndex[0] < 4)
        {
            if (AILocationIndex[0] - 1 >= 0 && AILocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (AILocationIndex[0] - 1 >= 0 && AILocationIndex[1] <= _MapController._MapSize[AILocationIndex[0] - 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1]].GetComponent<Tile>());
            }
            if (AILocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (AILocationIndex[1] + 1 <= _MapController._MapSize[AILocationIndex[0]]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (AILocationIndex[0] + 1 <= _MapController._MapSize.Length-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]].GetComponent<Tile>());
            }
            if (AILocationIndex[0] + 1 <= _MapController._MapSize.Length-1 && AILocationIndex[1] + 1 <= _MapController._MapSize[AILocationIndex[0] + 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1] + 1].GetComponent<Tile>());
            }
        }
        else if (AILocationIndex[0] == 4)
        {
            if ( AILocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (  AILocationIndex[1] <= _MapController._MapSize[AILocationIndex[0] - 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1]].GetComponent<Tile>());
            }
            if (AILocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (AILocationIndex[1] + 1 <= _MapController._MapSize[AILocationIndex[0]]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] + 1].GetComponent<Tile>());
            }
            if ( AILocationIndex[1]-1>=0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]-1].GetComponent<Tile>());
            }
            if ( AILocationIndex[1] + 1 <= _MapController._MapSize[AILocationIndex[0] + 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]].GetComponent<Tile>());
            }
        }
        else if (AILocationIndex[0] > 4)
        {
            if (AILocationIndex[0] - 1 >= 0 && AILocationIndex[1] >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1]].GetComponent<Tile>());
            }
            if (AILocationIndex[0] - 1 >= 0 && AILocationIndex[1]+1 <= _MapController._MapSize[AILocationIndex[0] - 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] - 1][AILocationIndex[1]+1].GetComponent<Tile>());
            }
            if (AILocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (AILocationIndex[1] + 1 <= _MapController._MapSize[AILocationIndex[0]]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0]][AILocationIndex[1] + 1].GetComponent<Tile>());//error
            }
            if (AILocationIndex[0] + 1 <= _MapController._MapSize.Length-1 && AILocationIndex[1]-1 >=0)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]-1].GetComponent<Tile>());
            }
            if (AILocationIndex[0] + 1 <= _MapController._MapSize.Length-1 && AILocationIndex[1]  <= _MapController._MapSize[AILocationIndex[0] + 1]-1)
            {
                Check.Add(_MapController._MapTile[AILocationIndex[0] + 1][AILocationIndex[1]].GetComponent<Tile>());
            }
        }


        //----------------------------------------------------------------------------------
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

        this.transform.position = NextTile.transform.position +Vector3.up *1.0f;
        AILocationIndex = NextTile.TileLocationIndex;
    }

    private void Awake()
    {
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        AILocationIndex = _MapController._AIFirstLocationIndex;
    }

}