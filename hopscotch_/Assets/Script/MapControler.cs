using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{

    private Vector3[][] MapArr;    
    public GameObject _tile;
    
    public void CreateMapArr(int level) 
    {
        
        int sidelength = level + 2;
        int height = 2 * sidelength - 1; //5
        MapArr = new Vector3[height][];
        for (int i = 0; i < sidelength; i++)
        {
            MapArr[i] = new Vector3[sidelength + i];
            MapArr[height - i - 1] = new Vector3[sidelength + i];
            for (int j = 0; j < sidelength +i; j++)
            {
                if (i <= sidelength)
                {                    
                    MapArr[i][j] = new Vector3(-1.0f * i + j, 0.0f, 0.866f * j);
                    MapArr[height-i-1][j] = new Vector3(-1.0f * (height-i-1) + j, 0.0f, 0.866f * j);
                }
             
            }
        }

        /*        0 ****
         *        1*****
         *       2******
         *       3*******
         *       4******
         *       5*****
         *       6****
         *       */

        
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
