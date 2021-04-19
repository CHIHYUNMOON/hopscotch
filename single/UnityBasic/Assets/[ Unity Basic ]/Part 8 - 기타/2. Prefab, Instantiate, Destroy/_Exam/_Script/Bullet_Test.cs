using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Test : MonoBehaviour
{
    //---------------------------
    Transform _myTrsf;
    public float _speed = 2f;
    public float _destroyTime = 2f;
    //---------------------------
    private void Awake()
    {
        _myTrsf = transform;
        Destroy(gameObject, _destroyTime);
    }
    //---------------------------
    void Update() { _myTrsf.Translate(0, 0, _speed * Time.deltaTime); }
    //---------------------------
}
