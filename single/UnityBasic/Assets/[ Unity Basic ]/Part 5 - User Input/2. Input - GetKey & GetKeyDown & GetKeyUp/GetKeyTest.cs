//=================================================================
/*
    2)	Input.GetKey 계열 함수
    [참고 :	https://docs.unity3d.com/ScriptReference/Input.GetKey.html
			https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
			https://docs.unity3d.com/ScriptReference/Input.GetKeyUp.html
    ]
*/
//=================================================================
/*	
	-------------------------------
	bool GetKey(string name)
	bool GetKey(KeyCode key)

	-	Input Manager의 축 이름이나 KeyCode에 명시된 타입의 키가 
		눌리고 있는지 체크하여 true or false 값 반환.

		============================================================
					|	true				    |	false
		------------------------------------------------------------
		GetKey		|	눌리고 있는 동안.		|
		----------------------------------------
		GetKeyDown	|	눌린 순간.			    |	    그 외 상황.
		----------------------------------------
		GetKeyUp	|	눌렀다가 뗀 순간.		|
		============================================================
		
*/
//=================================================================
using UnityEngine;
//=================================================================
public class GetKeyTest : MonoBehaviour
{
	//-------------------------------
    void Update()
    {
		if( Input.GetKeyDown( KeyCode.Space ) )
			Debug.Log( "Space Bar is Down");

		if( Input.GetKey( KeyCode.Space ) )
			Debug.Log( "Space Bar is Pressing");

		if( Input.GetKeyUp( KeyCode.Space ) )
			Debug.Log( "Space Bar is Up");

    }//	void Update()
	//-------------------------------

}//	public class GetKeyTest : MonoBehaviour
 //=================================================================
 /*
  * Q 1)
  *		스페이스 버튼을 누르는 동안 박스의 길이가 길어지고
  *		스페이스 버튼을 떼면 다시 원래대로 길이가 돌아오도록
  *		프로그램 합니다.
 */
 //=================================================================