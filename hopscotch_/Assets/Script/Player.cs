using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //------------------------------------------
    private static Player _inst;
    public static Player _Inst { get { return _inst; } }
    //------------------------------------------
    protected UIManager _uIManager;
    protected GameObject _tile;
    public GameObject _Tile { get { return _tile; } }
    protected GameObject _nextTile;
    public GameObject NextTile { get { return _nextTile; } set { _nextTile = value; } }
    protected MapController _MapController;
    protected Animator _animator;
    public Animator Animator { get { return _animator; } }
    
    //------------------------------------------
    protected int _playerScore = 0;
    public int PlayerScore {get { return _playerScore; } set { _playerScore = value; } }
    public static bool _isYourTurn = true;
    protected int[] PlayerLocationIndex;
    protected float _moveSpeed = 0.5f;




    public virtual void CharacterMove(Tile nextTile)
    {   
            Quaternion tmp = Quaternion.LookRotation(nextTile.gameObject.transform.position - this.gameObject.transform.position);
            Vector3 tmpEuler = tmp.eulerAngles;
            tmpEuler.x = 0f;
            gameObject.transform.rotation = Quaternion.Euler(tmpEuler);

            this.gameObject.transform.Translate(Vector3.forward);        
    }

    public virtual void CharacterMove() {
        return;
    }

    private void Awake()
    {
        _inst = this;
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _animator = GetComponent<Animator>();
    }
    //------------------------------------------

    


    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile"))
        {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>().Score;
                PlayerLocationIndex = _tile.GetComponent<Tile>().TileLocationIndex;
                
            }
        }
    }

    public virtual List<Tile> CheckTileCanMove()
    {
        List<Tile> Check = new List<Tile>();
        if (PlayerLocationIndex[0] < 4)
        {
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] <= _MapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _MapController._MapSize.Length - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _MapController._MapSize.Length - 1 && PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
        }
        else if (PlayerLocationIndex[0] == 4)
        {
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] <= _MapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
        }
        else if (PlayerLocationIndex[0] > 4)
        {
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] - 1 >= 0 && PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0] - 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] - 1][PlayerLocationIndex[1] + 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[1] + 1 <= _MapController._MapSize[PlayerLocationIndex[0]] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0]][PlayerLocationIndex[1] + 1].GetComponent<Tile>());//error
            }
            if (PlayerLocationIndex[0] + 1 <= _MapController._MapSize.Length - 1 && PlayerLocationIndex[1] - 1 >= 0)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1] - 1].GetComponent<Tile>());
            }
            if (PlayerLocationIndex[0] + 1 <= _MapController._MapSize.Length - 1 && PlayerLocationIndex[1] <= _MapController._MapSize[PlayerLocationIndex[0] + 1] - 1)
            {
                Check.Add(_MapController._MapTile[PlayerLocationIndex[0] + 1][PlayerLocationIndex[1]].GetComponent<Tile>());
            }
        }

        if (Check.Count ==0) {
            GameManager.EndGame();
            return null;
        }
        return Check;
    }
}
  