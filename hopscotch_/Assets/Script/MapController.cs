using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    private Vector3[][] MapArr;    
    public GameObject[] _tile;
    private int _sidelength;
    public bool[][] _isOccupied;


    public void CreateMapArr(int level) 
    {        
        _sidelength = level + 4;
        int height = 2 * _sidelength - 1; 
        MapArr = new Vector3[height][];
        _isOccupied = new bool[height][];
        for (int i = 0; i < _sidelength; i++)
        {
            MapArr[i] = new Vector3[_sidelength + i];
            MapArr[height - i - 1] = new Vector3[_sidelength + i];
            _isOccupied[i] = new bool[_sidelength + i];
            _isOccupied[height - i - 1] = new bool[_sidelength + i];

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

                    GameObject maptile = Instantiate(_tile[UnityEngine.Random.Range(0, _tile.Length)]);
                    maptile.transform.position = MapArr[i][j];
                    
                }

            }
        }

        

    }
    private void Awake()
    {
        CreateMapArr(1);
    }
    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
