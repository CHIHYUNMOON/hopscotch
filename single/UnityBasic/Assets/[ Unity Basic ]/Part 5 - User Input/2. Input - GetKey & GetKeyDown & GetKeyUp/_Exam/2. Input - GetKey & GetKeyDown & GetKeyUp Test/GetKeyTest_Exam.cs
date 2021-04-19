//=========================================================
using UnityEngine;
//=========================================================
public class GetKeyTest_Exam : MonoBehaviour
{
    //----------------------
    Transform _myTransf;
    public float _scaleX = 0.001f;
    //----------------------
    void Start() { _myTransf = transform; }
    //----------------------
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 tmpScale = _myTransf.localScale;
            tmpScale.x += _scaleX;
            _myTransf.localScale = tmpScale;
        }

        if (Input.GetKeyUp(KeyCode.Space))
            _myTransf.localScale = Vector3.one;

    }// void Update()
    //----------------------

}// public class GetKeyTest_Exam : MonoBehaviour
 //=========================================================