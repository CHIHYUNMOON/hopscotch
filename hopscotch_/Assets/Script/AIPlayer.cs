using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    public override List<Tile> CheckTileCanMove()
    {
        return base.CheckTileCanMove();
    }
    public void AIMove()
    {
        List<Tile> Check = CheckTileCanMove();
        Tile NextTile = null;
        int MaxScore = 0;

        foreach (Tile T in Check)
        {
            if (!T._isOccupied)
            {
                if (T.Score > MaxScore)
                {
                    MaxScore = T.Score;
                    NextTile = T;
                }
            }
        }
        if (NextTile == null)
        {
            //GameManager.EndGame();
        }
        else
        {
            this.transform.position = NextTile.transform.position + Vector3.up * 1.0f;
            PlayerLocationIndex = NextTile.TileLocationIndex;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile"))
        {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>().Score;
                PlayerLocationIndex = _tile.GetComponent<Tile>().TileLocationIndex;
                _uIManager.AIScore.text = "AI Score : "+ _playerScore.ToString();
            }
        }
    }



    private void Awake()
    {
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        PlayerLocationIndex = _MapController._AIFirstLocationIndex;
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

}