using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{

    private Vector3[][] MapArr;    
    public GameObject _tile;
    
    public void CreateMapArr(int level) 
    {
        
        int sidelength = level + 4;
        int height = 2 * sidelength - 1;
        MapArr = new Vector3[height][];
        for (int i = 0; i < height; i++) {
            
            for (int j = 0; j < sidelength +i; j++) {
                if (i <= sidelength)
                {
                    MapArr[i] = new Vector3[sidelength + i];
                    MapArr[i][j] = new Vector3(-0.5f * i + j, 0.0f, 0.866f * j);
                }
                else
                {
                    MapArr[i] = new Vector3[MapArr[height-1].Length];
                    MapArr[i][j] = MapArr[2 * sidelength -i][j];
                }
            }
        }

        
    }
    public void LocateTile(Vector3[][] mapArr)     
    {
        for (int i = 0; i < mapArr.Length; i++)
        {
            for (int j = 0; j < mapArr[i].Length ; j++) {
                GameObject maptile = Instantiate(this._tile);
                maptile.transform.position = mapArr[i][j];
            }
        }

    }
    // Start is called before the first frame update
    void Start()  
    {
        CreateMapArr(1);
        LocateTile(MapArr);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
