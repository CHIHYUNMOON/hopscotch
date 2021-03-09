using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //------------------------------------------
    static Player _inst;
    public static Player _Inst { get { return _inst; } }
    //------------------------------------------
    public UIManager uIManager;
    protected GameObject _tile;
    public GameObject _Tile { get { return _tile; } }

    protected MapController _MapController;
    //------------------------------------------
    public int _playerScore = 0;
    public static bool _isYourTurn = true;
    protected int[] PlayerLocationIndex;
    




    private void Awake()
    {
        _inst = this;
        _MapController = GameObject.Find("MapController").GetComponent<MapController>();
        

    }
    //------------------------------------------

    


    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MapTile"))
        {
            _tile = collision.gameObject;
            if (!_tile.GetComponent<Tile>()._isOccupied)
            {
                _playerScore += _tile.GetComponent<Tile>()._score;
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
        }

        return Check;
    }

    

}
  