//=================================================================
/*
 * Q 1)
 *		씬에 큐브를 두개 만든다.
 *		하나는 Input.GetAxis, 다른 하나는 Input.GetAxisRaw를 이용하여
 *		왼쪽 버튼을 누르면 왼쪽으로, 오른쪽 버튼을 누르면 오른쪽으로 이동하고
 *		아무버튼도 누르지 않으면 제자리로 돌아가도록 만든다. *		
*/
//=================================================================
using UnityEngine;
//=================================================================
public class GetAxisAndAxisRawTest_Exam : MonoBehaviour
{
	//-------------------------------
    public float _speed = 10.0f;
	public Transform _trsfAxis;
	public Transform _trsfAxisRaw;
	//-------------------------------
	void Update()
    {
		Vector3 curPos = _trsfAxis.position;
		curPos.x = Input.GetAxis("Horizontal") * _speed;
		_trsfAxis.position = curPos;

		curPos = _trsfAxisRaw.position;
		curPos.x = Input.GetAxisRaw("Horizontal") * _speed;
		_trsfAxisRaw.position = curPos;
        
    }//	void Update()
	//-------------------------------

}//	public class GetAxisAndAxisRawTest : MonoBehaviour
//=================================================================