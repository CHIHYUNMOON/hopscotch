﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    private Vector3[][] MapArr;    
    public GameObject[] _tile;
    private int _sidelength;
    
    public void CreateMapArr(int level) 
    {
        
        _sidelength = level + 4;
        int height = 2 * _sidelength - 1; 
        MapArr = new Vector3[height][];
        for (int i = 0; i < _sidelength; i++)
        {
            MapArr[i] = new Vector3[_sidelength + i];
            MapArr[height - i - 1] = new Vector3[_sidelength + i];
            for (int j = 0; j < _sidelength +i; j++)
            {
                if (i <= _sidelength)
                {                    
                    MapArr[i][j] = new Vector3(-0.5f * i + j, 0.0f, 0.866f * i);
                    MapArr[height-i-1][j] = new Vector3(-0.5f * i + j, 0.0f, 0.866f * (height-i-1));
                }
             
            }
        }
        for (int i = 0; i < MapArr.Length; i++)
        {
            for (int j = 0; j < MapArr[i].Length; j++)
            {

                if (i != _sidelength - 1 || j != _sidelength - 1)
                {

                    GameObject maptile = Instantiate(_tile[UnityEngine.Random.Range(0, _tile.Length)]);
                    maptile.transform.position = MapArr[i][j];

                }

            }
        }



    }
    //public void LocateTile(Vector3[][] mapArr)     
    //{
    //    for (int i = 0; i < mapArr.Length; i++)
    //    {
    //        for (int j = 0; j < mapArr[i].Length ; j++) {
                
    //            if (i != _sidelength - 1 || j != _sidelength - 1) { 
                    
    //                GameObject maptile = Instantiate(_tile[UnityEngine.Random.Range(0,_tile.Length)]);
    //                maptile.transform.position = mapArr[i][j];
                
    //            }
                
    //        }
    //    }

    //}
    // Start is called before the first frame update
    void Start()  
    {
        CreateMapArr(1);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}