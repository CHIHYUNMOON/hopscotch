using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //---------------------------------------------------------------------------------------------------------
    private static Character _player1;
    public static Character _Player1 { get { return _player1; } set { _player1 = value; } }
    private static Character _player2;
    public static Character _Player2 { get { return _player2; } set { _player2 = value; } }
    //---------------------------------------------------------------------------------------------------------
    private MapController _mapController;
    public MapController _MapController { get { return _mapController; } set { _mapController = value; } }
    private UIManager _uIManager;
    public static int _turnNumber=0;
    private static int _level = 1;
    //---------------------------------------------------------------------------------------------------------
    private static bool _isPlayer1Turn = true;
    public static bool _IsPlayer1Turn  { get { return _isPlayer1Turn; } set { _isPlayer1Turn = value; } }
    private static bool _isPlayer2Turn = false;
    public static bool _IsPlayer2Turn { get { return _isPlayer2Turn; } set { _isPlayer2Turn = value; } }
    //---------------------------------------------------------------------------------------------------------
    public static bool _isGameStart=false;
    public bool _isGameEnd = false;
    public static bool _isPlayer2GameStart;
    public static int _Level  { get { return _level; } }

    //---------------------------------------------------------------------------------------------------------
    [SerializeField]
    private  GameObject[] CharacterArr;
    
    //---------------------------------------------------------------------------------------------------------
    private Tile _nextTile;
    public Tile _NextTile { get { return _nextTile; } set { _nextTile = value; } }
    public static int _Player1Character { get; set; }
    public static int _Player2Character { get; set; }
    IEnumerator TurnChanger()
    {
        while (!_isGameEnd)
        {
            if (!_isGameStart) {
                yield return null;
            }
            else
            {
                if (_turnNumber == 0)
                {
                    if (_isPlayer1Turn)
                    {                       
                        _mapController.CreateCharacter(_nextTile, CharacterArr[_Player1Character]);
                    }
                    else if(_isPlayer2Turn)
                    {
                        yield return new WaitForSeconds(1.0f);
                        _mapController.CreateCharacter(null ,CharacterArr[0]);
                        _turnNumber++; 
                    }
                    _isPlayer1Turn = !_isPlayer1Turn;
                    _isPlayer2Turn = !_isPlayer1Turn;
                }

                else if (_turnNumber > 0)
                {                    
                    if (_isPlayer1Turn)
                    {
                        _player1._isYourTurn = _isPlayer1Turn;
                        //Player1 turn
                        Debug.Log("Start Player1 Turn");
                        yield return new WaitUntil(() => _player1._isYouSelectTile);
                        yield return new WaitUntil(() => !_player1._isYourTurn);
                        yield return new WaitUntil(() => !_player1._isMove);
                        Debug.Log("End Player1 Turn");
                    }

                    else if (_isPlayer2Turn )
                    {
                        _player2._isYourTurn = _isPlayer2Turn;
                        Debug.Log("Start Player2 Turn");
                        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f,2.0f));
                        if (!_player2 is AIPlayer)
                        yield return new WaitUntil(() => _player2._isYouSelectTile);
                        yield return new WaitUntil(() => !_player2._isYourTurn);
                        yield return new WaitUntil(() => !_player2._isMove);
                        Debug.Log("End Player2 Turn");
                        _turnNumber++;                                                          
                    }   
                    EndGame();  
                }
                yield return null;
            }
            yield return null;
        }          
            
    }

    IEnumerator TwoPlayerTurnChanger() {
        while (!_isGameEnd) 
        {
            if (!_isGameStart)
            {
                yield return null;
            }
            else 
            {
                if (_turnNumber == 0) 
                {
                    if (_isPlayer1Turn)
                    {
                        Debug.Log("Start Player1 Turn");
                        _mapController.CreateCharacter(_nextTile, CharacterArr[_Player1Character]);
          
                        Debug.Log("End Player1 Turn");
                    }
                    else
                    {
                        Debug.Log("Start Player2 Turn");
                        yield return new WaitUntil(() => _isPlayer2GameStart);
                        _mapController.CreateCharacter(_nextTile, CharacterArr[_Player2Character]);
                        
                        Debug.Log("End Player2 Turn");
                        _turnNumber++;

                    }
                    _isPlayer1Turn = !_isPlayer1Turn;
                    _isPlayer2Turn = !_isPlayer1Turn;
                }
                else if (_turnNumber > 0)
                {
                    if (_isPlayer1Turn)
                    {
                        _player1._isYourTurn = _isPlayer1Turn;
                        //Player1 turn
                        Debug.Log("Start Player1 Turn");
                        yield return new WaitUntil(() => _player1._isYouSelectTile);
                        yield return new WaitUntil(() => !_player1._isYourTurn);
                        yield return new WaitUntil(() => !_player1._isMove);
                        Debug.Log("End Player1 Turn");
                    }

                    else if (_isPlayer2Turn)
                    {
                        _player2._isYourTurn = _isPlayer2Turn;
                        Debug.Log("Start Player2 Turn");                       
                        yield return new WaitUntil(() => _player2._isYouSelectTile);
                        yield return new WaitUntil(() => !_player2._isYourTurn);
                        yield return new WaitUntil(() => !_player2._isMove);
                        Debug.Log("End Player2 Turn");
                        _turnNumber++;
                    }

                    EndGame();
                }



            }

            yield return null;
        }

        yield return null;
    }


    private void EndGame()
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
            _uIManager.EndGameUI.SetActive(true);
                    
        }    
    }

    

    void Awake()
    {
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _turnNumber = 0;
        _isPlayer1Turn = true;
        _isPlayer2Turn = false;
        _isGameEnd = false;
        _isGameStart = false;
        _isPlayer2GameStart = false;
        

    }

    private void Start()
    {
        if (LobbyManager.Mode == 1)
            StartCoroutine(TurnChanger());
        else if (LobbyManager.Mode == 2)
            StartCoroutine(TwoPlayerTurnChanger()); 
    }
    private void Update()
    {
       

    }

}
