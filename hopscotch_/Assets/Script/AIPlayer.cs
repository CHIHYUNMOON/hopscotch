using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Character
{
    public override List<Tile> CheckTileCanMove()
    {
        return base.CheckTileCanMove();
    }

    public void AISelectTile()
    {
        List<Tile> Check = CheckTileCanMove();
        Tile tmp = null;
        int MaxScore = 0;

        foreach (Tile T in Check)
        {
            if (!T._isOccupied)
            {
                if (T.Score > MaxScore)
                {
                    MaxScore = T.Score;
                    tmp = T;
                }
            }
        }
        _playerLocationIndex = tmp.TileLocationIndex;
        _gameManager._NextTile = tmp;
        _isYouSelectTile = true;
    }

    //public override IEnumerator CharacterMove(Tile nextTile)
    //{

    //    //---------------------------------------------------------------------------
    //    //Quaternion tmp = Quaternion.LookRotation(nextTile.gameObject.transform.position - this.gameObject.transform.position);
    //    //Vector3 tmpEuler = tmp.eulerAngles;
    //    //tmpEuler.x = 0f;
    //    //gameObject.transform.rotation = Quaternion.Euler(tmpEuler);
    //    //this.gameObject.transform.Translate(Vector3.forward);     
    //    base.CharacterMove(nextTile);
    //    yield return null;
    //}


    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile"))
        {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>().Score;
                _playerLocationIndex = _tile.GetComponent<Tile>().TileLocationIndex;
                _uIManager.AIScore.text = "AI Score : "+ _playerScore.ToString();
            }
        }
    }



    protected override void Awake()
    {
        base.Awake();
        
    }

    protected override void Update()
    {
        base.Update();
    }

}