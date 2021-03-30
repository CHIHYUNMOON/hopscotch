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
    protected int[] PlayerLocationIndex;
    public bool _isYouSelectTile;
    //---------------------------------------------------------------------------------
    



    //---------------------------------------------------------------------------------
    public abstract void CharacterMove(Tile nextTile);
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

    public virtual List<Tile> CheckTileCanMove()
    {
        List<Tile> Check = new List<Tile>();
        if (PlayerLocationIndex[0] < 4)
        {
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] <= _mapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
        }
        else if (PlayerLocationIndex[0] == 4)
        {
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] <= _mapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
        }
        else if (PlayerLocationIndex[0] > 4)
        {
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _mapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());//error
            }
            if (PlayerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _mapController._MapSize.Length - 1 && PlayerLocationIndex[1] <= _mapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_mapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
        }

        if (Check.Count == 0)
        {
            return null;
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
                PlayerLocationIndex = _tile.GetComponent<Tile>().TileLocationIndex;
                _uIManager.PlayerScore.text = "Player Score : " + _playerScore.ToString();
            }
        }
    }

}
