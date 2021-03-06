﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    //----------------------------------------------------------
    private Vector3[][] MapArr;
    public Vector3[][] _MapArr { get { return MapArr; } }
    //----------------------------------------------------------
    [SerializeField]
    private GameObject[] _tile;
    private GameObject[][] _mapTile;
    public GameObject[][] _MapTile { get { return _mapTile; } }
    //----------------------------------------------------------
    //-------- Player Prefabs-------
    [SerializeField]
    private GameObject _aiPrefab;
    public GameObject AIPrefab { get { return _aiPrefab; } }

    [SerializeField]
    private GameObject _playerPrefab;
    public GameObject PlayerPrefab { get { return _playerPrefab; } }

    [HideInInspector]
    public static GameObject _player2Instance;
    [HideInInspector]
    public static GameObject _player1Instance;

    //----------------------------------------------------------
    private int _sidelength;
    int[] _mapSize = new int[] {5, 6, 7, 8, 9, 8, 7, 6, 5 };
    public int[] _MapSize { get { return _mapSize; } }

    //----------------------------------------------------------
    private int[] AIFirstLocationIndex;
    public int[] _AIFirstLocationIndex { get { return AIFirstLocationIndex; } }
    //----------------------------------------------------------

    
    public void CreateMapArr(int level) 
    {        
        _sidelength = level + 4;
        int height = 2 * _sidelength - 1; 
        MapArr = new Vector3[height][];   
        _mapTile = new GameObject[height][];
        

        for (int i = 0; i < _sidelength; i++)
        {
            MapArr[i] = new Vector3[_sidelength + i];
            MapArr[height - i - 1] = new Vector3[_sidelength + i];
            //-----------------------------------------------
            
            //-----------------------------------------------
            _mapTile[i] = new GameObject[_sidelength + i];
            _mapTile[height - i - 1] = new GameObject[_sidelength + i];
            for (int j = 0; j < _sidelength +i; j++)
            {
                if (i <= _sidelength)
                {                    
                    MapArr[i][j] = new Vector3(-0.5f * i + j-2f, 0.0f, 0.866f * i - 3.464f);
                    MapArr[height-i-1][j] = new Vector3(-0.5f * i + j-2f, 0.0f, 0.866f * (height-i-1) -3.464f);
                   
                }     
            }
        }
        for (int i = 0; i < MapArr.Length; i++)
        {
            for (int j = 0; j < MapArr[i].Length; j++)
            {        
                    _mapTile[i][j] = Instantiate(_tile[UnityEngine.Random.Range(0, _tile.Length)]);
                    _mapTile[i][j].transform.position = MapArr[i][j];
                    _mapTile[i][j].GetComponent<Tile>().TileLocationIndex[0] = i;
                    _mapTile[i][j].GetComponent<Tile>().TileLocationIndex[1] = j;
            }
        }
    }


    public void CreateCharacter(Tile FirstTile , GameObject PlayerPrefab)
    {
        if (!FirstTile._isOccupied)
        {
            if (GameManager._IsPlayer1Turn)
            {
                _player1Instance = Instantiate(PlayerPrefab);
                _player1Instance.transform.position = FirstTile.gameObject.transform.position + Vector3.up * 1.0f;
                _player1Instance.GetComponent<Character>()._PlayerLocationIndex = FirstTile.TileLocationIndex;
                _player1Instance.tag = "Player1";
                GameManager._Player1 = _player1Instance.GetComponent<Character>();
            }
            else if (GameManager._IsPlayer2Turn)
            {
                if (FirstTile == null)
                {
                    AIFirstLocationIndex = new int[2];
                    AIFirstLocationIndex[0] = UnityEngine.Random.Range(0, _mapSize.Length);
                    AIFirstLocationIndex[1] = UnityEngine.Random.Range(0, _mapSize[AIFirstLocationIndex[0]]);
                    while (_mapTile[AIFirstLocationIndex[0]][AIFirstLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                    {
                        AIFirstLocationIndex[0] = UnityEngine.Random.Range(0, _mapSize.Length);
                        AIFirstLocationIndex[1] = UnityEngine.Random.Range(0, _mapSize[AIFirstLocationIndex[0]]);
                        if (!_mapTile[AIFirstLocationIndex[0]][AIFirstLocationIndex[1]].GetComponent<Tile>()._isOccupied)
                        {
                            break;
                        }
                    }
                    FirstTile = _mapTile[AIFirstLocationIndex[0]][AIFirstLocationIndex[1]].GetComponent<Tile>();
                }

                //------------------------------------------------------------------------    
                _player2Instance = Instantiate(PlayerPrefab);
                _player2Instance.transform.position = FirstTile.gameObject.transform.position + Vector3.up * 1.0f;
                _player2Instance.GetComponent<Character>()._PlayerLocationIndex = FirstTile.TileLocationIndex;
                _player2Instance.tag = "Player2";
                GameManager._Player2 = _player2Instance.GetComponent<Character>();
            }
        }
    }


    private void Awake()
    {
        
        CreateMapArr(GameManager._Level);      
    }

    
}
