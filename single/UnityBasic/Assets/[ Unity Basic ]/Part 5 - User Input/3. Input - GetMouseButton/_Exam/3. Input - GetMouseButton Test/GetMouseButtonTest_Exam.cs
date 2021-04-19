//================================================================
using UnityEngine;
//================================================================
public class GetMouseButtonTest_Exam : MonoBehaviour
{
    //------------------------
    Transform _myTrsf;
    public float _moveOffset = 2f;
    //------------------------
    void Start() { _myTrsf = transform; }
    //------------------------
    void Update()
    {
        Vector2 mouseWheel2 = Input.mouseScrollDelta;
        if (mouseWheel2.y > 0 || mouseWheel2.y < 0)
        {
            Vector2 tmpPos = mouseWheel2;
            transform.position += new Vector3(tmpPos.x, tmpPos.y * _moveOffset, 0f);
        }
    }
    //------------------------

}// public class GetMouseButtonTest_Exam : MonoBehaviour
 //================================================================