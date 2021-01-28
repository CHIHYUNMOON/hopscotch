using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
    
    
    public GameObject _tile;

    public void LocateTile(int level)     
    {
        int sidelength = level + 4;
        
        for (int i = 0; i <  2 * sidelength-1; i++)
        {
            for (int j = 0; j < sidelength+i; j++)
            {
                if (j <i)
                {
                    GameObject maptile = Instantiate(this._tile) as GameObject;
                    maptile.transform.position = new Vector3((float)0.5 * i - j, 0.0f, (float)0.866 * i);

                }
                else
                {
                    GameObject maptile = Instantiate(this._tile) as GameObject;
                    maptile.transform.position = new Vector3((float)0.5 * i + j, 0.0f, (float)0.866 * i);
                    
                }
            } 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LocateTile(1);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
