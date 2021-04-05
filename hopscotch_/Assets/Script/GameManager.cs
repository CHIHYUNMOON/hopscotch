using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private  Character _player1;
    public Character _Player1 { get { return _player1; } set { _player1 = value; } }
    private Character _player2;
    public Character _Player2 { get { return _player2; } set { _player2 = value; } }
    private MapController _mapController;
   
    public static int _turnNumber=0;
    private static int _level = 1;

    private static bool _isPlayer1Turn = true;
    public static bool _IsPlayer1Turn  { get { return _isPlayer1Turn; } set { _isPlayer1Turn = value; } }

    private static bool _isPlayer2Turn = false;
    public static bool _IsPlayer2Turn { get { return _isPlayer2Turn; } set { _isPlayer2Turn = value; } }
    public static bool _isGameStart=false;
    private bool _isGameEnd = false;

    public static int _Level  { get { return _level; } }



    private Tile _nextTile;
    public Tile _NextTile { get { return _nextTile; } set { _nextTile = value; } }


    IEnumerator TurnChanger()
    {
        while (!_isGameEnd)
        {
            
            if (!_isGameStart)
                yield return null;
            else
            {
                if (_turnNumber == 0)
                {
                    //creat Player & AI
                    if (_isPlayer1Turn)
                    {
                        
                        _mapController.CreateCharacter(_nextTile);
                    }
                    else if(_isPlayer2Turn)
                    {
                        yield return new WaitForSeconds(1.0f);
                        _mapController.CreateCharacter(null);
                        _turnNumber++; //Finish First turn
                    }
                    _isPlayer1Turn = !_isPlayer1Turn;
                    _isPlayer2Turn = !_isPlayer1Turn;

                }
                else if (_turnNumber > 0)
                {
                    
                    if (_isPlayer1Turn )
                    {
                        //Player1 turn
                        Debug.Log("Start Player1 Turn");
                        yield return new WaitUntil(() => _player1._isYouSelectTile);
                        StartCoroutine(CharacterMove(_nextTile));
                        //yield return new WaitWhile(() => _player1._isMove);
                       // _player1.CharacterMove(_nextTile);
                        Debug.Log("End Player1 Turn");
                    }

                    else if (_isPlayer2Turn )
                    {
                        Debug.Log("Start Player2 Turn");
                        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f,2.0f));
                        //Player2 Turn
                        //_player2.CharacterMove(_nextTile);
                        StartCoroutine(CharacterMove(_nextTile));
                        Debug.Log("End Player2 Turn");
                        _turnNumber++;
                        
                    }
                    StartCoroutine(EndGame());
                }
                
                

                yield return null;
            }
            yield return null;
        }          
            
    }


    IEnumerator  EndGame()
    {
        
        
        if (_isPlayer1Turn)
        {
            if (_player1.CheckTileCanMove().Count == 0)
            {
                _player2.PlayerScore += 10;
                _isGameEnd = true;
                Debug.Log("Player2 gets 10 points");
            }
        }
        else if (_isPlayer2Turn)
        {
            if (_player2.CheckTileCanMove().Count == 0)
            {
                _player1.PlayerScore += 10;
                _isGameEnd = true;
                Debug.Log("Player1 gets 10 points");
            }
        }


        if (_isGameEnd)
        {
            if (_player1.PlayerScore > _player2.PlayerScore)
            {
                //_player1.Animator.SetBool(_is)
                Debug.Log("Player1 Win");
                _player1.Animator.SetBool("isWin", true);
                _player2.Animator.SetBool("isLose", true);
            }
            else if (_player1.PlayerScore < _player2.PlayerScore)
            {
                Debug.Log("Player2 Win");
                _player2.Animator.SetBool("isWin", true);
                _player1.Animator.SetBool("isLose", true);
            }
            else if (_player1.PlayerScore == _player2.PlayerScore)
            {
                Debug.Log("Draw");
            }
        }
        yield return null;
    }

    public virtual IEnumerator CharacterMove(Tile nextTile)
    {
        Character ThisTurnPlayer;
        if (_isPlayer1Turn)
        {
            ThisTurnPlayer = _player1;
        }
        else 
        {
            ThisTurnPlayer = _player2;
        }

        Vector3 LookDirection = nextTile.gameObject.transform.position - ThisTurnPlayer.gameObject.transform.position;
        Quaternion tmpQuat = Quaternion.LookRotation(LookDirection);
        Vector3 tmpEuler = tmpQuat.eulerAngles;
        tmpEuler.x = 0f;

        ThisTurnPlayer.gameObject.transform.rotation = Quaternion.Euler(tmpEuler);
        if (Vector3.Distance(nextTile.gameObject.transform.position, ThisTurnPlayer.gameObject.transform.position) > 0.3f)
        {
            ThisTurnPlayer.Animator.SetBool("isMoving", true);
            ThisTurnPlayer.gameObject.transform.position += LookDirection.normalized * 0.1f;
            
            yield return null;
        }
        else 
        {
            ThisTurnPlayer.Animator.SetBool("isMoving", false);
            ThisTurnPlayer._isYouSelectTile = false;
            _isPlayer1Turn = !_isPlayer1Turn;
            _isPlayer2Turn = !_isPlayer1Turn;
            yield return null;
        }
        //this.gameObject.transform.Translate(Vector3.forward);
        Debug.Log("Character Move");
        yield return null;
    }

    void Awake()
    {
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        
    }
    private void Start()
    {
        StartCoroutine(TurnChanger());
    }
    
}
