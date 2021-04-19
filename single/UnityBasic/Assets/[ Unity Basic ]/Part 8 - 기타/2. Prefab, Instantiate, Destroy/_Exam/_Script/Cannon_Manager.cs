//================================================
using UnityEngine;
//================================================
public class Cannon_Manager : MonoBehaviour
{
    //------------------------------
    public float _shotTime = 0.5f;
    float _curTime = 0f;
    //------------------------------
    public GameObject _bulletPref;
    public Transform _bulletSpawnPosL;
    public Transform _bulletSpawnPosR;
    //------------------------------
    private void Update()
    {
        if (_curTime >= _shotTime)
        {
            _curTime = 0f;

            if (Input.GetMouseButton(0))
            {
                Instantiate(_bulletPref, _bulletSpawnPosL.position, _bulletSpawnPosL.rotation);
                Instantiate(_bulletPref, _bulletSpawnPosR.position, _bulletSpawnPosR.rotation);
            }
        }
        else
            _curTime += Time.deltaTime;

    }// private void Update()
    //------------------------------

}// public class Cannon_Manager : MonoBehaviour
 //================================================