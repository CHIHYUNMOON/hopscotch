//=================================================================
/*	
    1)	Input.GetAxis & Input.GetAxisRaw
	[ 참고 :	https://docs.unity3d.com/ScriptReference/Input.GetAxis.html
    			https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html
	]
*/
//=================================================================
/*	
	-------------------------------
	float GetAxis(string axisName)
	-------------------------------
		-	axisName으로 축의 이름을 전달하여
			해당 축과 관련된 입력처리가 진행되었다면
			-1 ~ 1 사이의 실수값을 반환.
		-	입력이 없으면 0,
			입력이 있으면 -1 또는 1의 값이 반환됨.
			-	Sensitivity 수치에 따라 값이 증감.
				Gravity 수치에 따라 값이 0으로 보간.

	-------------------------------
	float GetAxisRaw(string axisName)
	-------------------------------
		-	GetAxis와 유사함.
		-	반환값은 -1, 0, 1 셋중 하나임.
		-	즉각적인 입력처리를 할때 사용.

*/
//=================================================================
using UnityEngine;
//=================================================================
public class GetAxisAndAxisRawTest : MonoBehaviour
{
	//-------------------------------
    public float _speed = 10.0f;
    public float _rotationSpeed = 100.0f;
	//-------------------------------
    void Update()
    {
		//*
        float trans = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal");
		//*/
		/*
		float trans = Input.GetAxisRaw("Vertical");
        float rot = Input.GetAxisRaw("Horizontal");
		//*/
		Debug.Log("trans : " + trans);
		Debug.Log("rot : " + rot);

		trans *= _speed;
		rot *= _rotationSpeed;
		        
        trans *= Time.deltaTime;
        rot *= Time.deltaTime;

		//	트랜스폼의 이동을 관리하는 함수.
        transform.Translate(0, 0, trans);

		//	트랜스폼의 회전을 관리하는 함수.
        transform.Rotate(0, rot, 0);

    }//	void Update()
	//-------------------------------

}//	public class GetAxisAndAxisRawTest : MonoBehaviour
//=================================================================
/*
 * Q 1)
 *		씬에 큐브를 두개 만든다.
 *		하나는 Input.GetAxis, 다른 하나는 Input.GetAxisRaw를 이용하여
 *		왼쪽 버튼을 누르면 왼쪽으로, 오른쪽 버튼을 누르면 오른쪽으로 이동하고
 *		아무버튼도 누르지 않으면 제자리로 돌아가도록 만든다. *		
*/
//=================================================================