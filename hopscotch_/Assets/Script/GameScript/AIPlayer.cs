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
        if (!_isYouSelectTile)
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
       
    }

    public override void CharacterMove(Tile nextTile)
    {
        if (!_gameManager._isGameEnd)
        {

            if (_isYourTurn )
            {
                AISelectTile();
                if (_isYouSelectTile)
                {
                    
                    Vector3 LookDirection = nextTile.gameObject.transform.position - this.gameObject.transform.position;
                    Quaternion tmpQuat = Quaternion.LookRotation(LookDirection);
                    Vector3 tmpEuler = tmpQuat.eulerAngles;
                    tmpEuler.x = 0f;
                    gameObject.transform.rotation = Quaternion.Euler(tmpEuler);

                    if (Vector3.Distance(nextTile.gameObject.transform.position, this.gameObject.transform.position) > 0.2f)
                    {
                        _animator.SetBool("isMoving", true);
                        gameObject.transform.position += LookDirection.normalized * Time.deltaTime *1.0f;


                    }
                    else
                    {
                        _animator.SetBool("isMoving", false);
                        _isYouSelectTile = false;
                        _isYourTurn = false;
                        GameManager._IsPlayer1Turn = !GameManager._IsPlayer1Turn;
                        GameManager._IsPlayer2Turn = !GameManager._IsPlayer2Turn;
                    }
                }
                
            }
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