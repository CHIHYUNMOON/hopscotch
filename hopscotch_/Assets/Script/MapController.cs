using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    private Vector3[][] MapArr;
    public Vector3[][] _MapArr { get { return MapArr; } }
    public GameObject[] _tile;
    private GameObject[][] _mapTile;
    public GameObject[][] _MapTile { get { return _mapTile; } }
    public GameObject AIPlayer;
    private int _sidelength;
    public bool[][] _isOccupied;
    private int[] AIFirstLocationIndex;
    public int[] _AIFirstLocationIndex { get { return AIFirstLocationIndex; } }

    public void CreateMapArr(int level) 
    {        
        _sidelength = level + 4;
        int height = 2 * _sidelength - 1; 
        MapArr = new Vector3[height][];
        _isOccupied = new bool[height][];
        _mapTile = new GameObject[height][];
        for (int i = 0; i < _sidelength; i++)
        {
            MapArr[i] = new Vector3[_sidelength + i];
            MapArr[height - i - 1] = new Vector3[_sidelength + i];
            //-----------------------------------------------
            _isOccupied[i] = new bool[_sidelength + i];
            _isOccupied[height - i - 1] = new bool[_sidelength + i];
            //-----------------------------------------------
            _mapTile[i] = new GameObject[_sidelength + i];
            _mapTile[height - i - 1] = new GameObject[_sidelength + i];
            for (int j = 0; j < _sidelength +i; j++)
            {
                if (i <= _sidelength)
                {                    
                    MapArr[i][j] = new Vector3(-0.5f * i + j, 0.0f, 0.866f * i);
                    MapArr[height-i-1][j] = new Vector3(-0.5f * i + j, 0.0f, 0.866f * (height-i-1));
                    _isOccupied[i][j] = false;
                    _isOccupied[height - i - 1][j] = false;
                }     
            }
        }
        for (int i = 0; i < MapArr.Length; i++)
        {
            for (int j = 0; j < MapArr[i].Length; j++)
            {

                if (i != _sidelength - 1 || j != _sidelength - 1) //총 타일 개수를 짝수로 맞춰주기 위해 가운데 타일은 빼 준다.
                {

                    _mapTile[i][j] = Instantiate(_tile[UnityEngine.Random.Range(0, _tile.Length)]);
                    _mapTile[i][j].transform.position = MapArr[i][j];

                }

            }
        }
    }
    private void CreateAI()
    {
        if (!Player._isYourTurn && GameManager._turnNumber ==1) {
            GameManager._turnNumber++;
            AIFirstLocationIndex = new int[2] { UnityEngine.Random.Range(0, 2 * _sidelength-1),UnityEngine.Random.Range(0, _sidelength) };
            if (AIFirstLocationIndex[0] == AIFirstLocationIndex[1]) {
                AIFirstLocationIndex = new int[2] { UnityEngine.Random.Range(0, 2 * _sidelength), UnityEngine.Random.Range(0, _sidelength) };
            }
            AIPlayer = Instantiate(AIPlayer);
            AIPlayer.transform.position = MapArr[AIFirstLocationIndex[0]][AIFirstLocationIndex[1]] +Vector3.up *1.0f;
            
        }

    }

    private void Awake()
    {
        CreateMapArr(GameManager._Level);      
    }
    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CreateAI", 3.0f);
        
    }
}
