using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    private static Character _inst;
    public static Character _Inst { get { return _inst; } }
    //---------------------------------------------------------------------------------
    protected GameObject _tile;
    public GameObject _Tile { get { return _tile; } }
    //---------------------------------------------------------------------------------
    protected int _playerScore = 0;
    public int PlayerScore { get { return _playerScore; } set { _playerScore = value; } }
    //---------------------------------------------------------------------------------
    protected MapController _mapController;
    protected UIManager _uIManager;
    protected GameManager _gameManager;
    protected Animator _animator;
    public Animator Animator { get { return _animator; } }
    protected int[] _playerLocationIndex;
    public int[] _PlayerLocationIndex { get { return _playerLocationIndex; } set { _playerLocationIndex = value; } }
    public bool _isYouSelectTile =false;
    public bool _isMove = false;
    public bool _isYourTurn;
    protected float _moveSpeed = 0.1f;
    //---------------------------------------------------------------------------------




    //---------------------------------------------------------------------------------
    
    //---------------------------------------------------------------------------------
    protected virtual void Awake()
    {       
        _inst = this;
        _mapController = GameObject.Find("MapController").GetComponent<MapController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _animator = GetComponent<Animator>();
        if (GameManager._IsPlayer1Turn)
            _gameManager._Player1 = this;
        else if (GameManager._IsPlayer2Turn)
            _gameManager._Player2 = this;


    }


    public  void DoCharacterMove( Tile nextTile)
    {
        //StartCoroutine(CharacterMove(nextTile));
    }

    public virtual void CharacterMove(Tile nextTile)
    {
        
        if (!_gameManager._isGameEnd)
        {

            if (_isYourTurn && _isYouSelectTile)
            {
                Vector3 LookDirection = nextTile.gameObject.transform.position - this.gameObject.transform.position;
                Quaternion tmpQuat = Quaternion.LookRotation(LookDirection);
                Vector3 tmpEuler = tmpQuat.eulerAngles;
                tmpEuler.x = 0f;
                gameObject.transform.rotation = Quaternion.Euler(tmpEuler);

                if (Vector3.Distance(nextTile.gameObject.transform.position, this.gameObject.transform.position) > 0.2f)
                {
                    _animator.SetBool("isMoving", true);
                    gameObject.transform.position += LookDirection.normalized * 0.01f;
           
                }
                else
                {
                    _animator.SetBool("isMoving", false);
                    _isYouSelectTile = false;
                    _isYourTurn = false;
                    //this.gameObject.transform.Translate(0,0,0);
                    GameManager._IsPlayer1Turn = !GameManager._IsPlayer1Turn;
                    GameManager._IsPlayer2Turn = !GameManager._IsPlayer2Turn;
                }
            }


           
        }
    }


    public virtual List<Tile> CheckTileCanMove()
    {
        List<Tile> Check = new List<Tile>();
        if (_playerLocationIndex[0] < 4)
        {
            if (_playerLocationIndex[0] - 1 >= 0 && _playerLocationIndex[1] - 1 >= 0 )
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1] - 1].GetComponent<Tile>()._isOccupied) 
                Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[0] - 1 >= 0 && _playerLocationIndex[1] <= _mapController._MapSize[_playerLocationIndex[0] - 1] - 1)
            {
                if(!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0]] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]+1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
            if (_playerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && _playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0] + 1] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]+1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1] + 1].GetComponent<Tile>());
            }
        }
        else if (_playerLocationIndex[0] == 4)
        {
            if (_playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] <= _mapController._MapSize[_playerLocationIndex[0] - 1] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0]] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]+1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0] + 1] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
        }
        else if (_playerLocationIndex[0] > 4)
        {
            if (_playerLocationIndex[0] - 1 >= 0 && _playerLocationIndex[1] >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
            if (_playerLocationIndex[0] - 1 >= 0 && _playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0] - 1] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1]+1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] - 1][_playerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[1] + 1 <= _mapController._MapSize[_playerLocationIndex[0]] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1]+1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0]][_playerLocationIndex[1] + 1].GetComponent<Tile>());//error
            }
            if (_playerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && _playerLocationIndex[1] - 1 >= 0)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]-1].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (_playerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && _playerLocationIndex[1] <= _mapController._MapSize[_playerLocationIndex[0] + 1] - 1)
            {
                if (!_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    Check.Add(_mapController._MapTile[_playerLocationIndex[0] + 1][_playerLocationIndex[1]].GetComponent<Tile>());
            }
        }
        

        
        
        return Check;
    }

   

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile"))
        {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>().Score;
                _playerLocationIndex = _tile.GetComponent<Tile>().TileLocationIndex;
                _uIManager.PlayerScore.text = "Player Score : " + _playerScore.ToString();
            }
        }
    }

    
    protected virtual void Update() 
    {
      
        CharacterMove(_gameManager._NextTile);
    }
    protected virtual void Start()
    {
       // StartCoroutine(CharacterMove(_gameManager._NextTile));
    }

}
