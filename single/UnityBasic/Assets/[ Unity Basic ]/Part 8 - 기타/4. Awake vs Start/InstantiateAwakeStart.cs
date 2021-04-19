using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAwakeStart : MonoBehaviour
{
    public GameObject _pref;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) {

            int posX = Random.Range(-5, 6);
            int posY = Random.Range(-5, 6);
            int posz = Random.Range(-5, 6);

            GameObject tmp = Instantiate( _pref, new Vector3( posX, posY, posz), Quaternion.identity);
            Debug.Log("Instantiate!!!");

        }
    }
}
