//================================================================
using UnityEngine;
//================================================================
public class ScriptTest_1 : MonoBehaviour
{
	//-----------------------------------------
	//	public으로 선언한 변수는 인스펙터 창에 노출되며,
	//	인스펙터 창에서 값을 편집할 수 있음.
	public int _myValue1 = 10;
	//-----------------------------------------
	//	private / protected의 경우 [ SerializeField ] 속성을 적용하면
	//	인스펙터창에 노출되어 편집 가능.
	[ SerializeField ]
	int _myValue2 = 5;
	//-----------------------------------------
	Light _light;
	//-----------------------------------------
	void CallStackTest() { Debug.Log("CallStack Test!!"); }
	//-----------------------------------------
	void Start()
    {
		Debug.Log("_myValue1 : " + _myValue1);		
		//	MonoBehaviour 클래스를 상속받는 클래스는
		//	new 와 클래스의 생성자로 생성할 수 없음.
        ScriptTest_2 tmp = new ScriptTest_2();
		if ( tmp == null )
			Debug.Log("new 연산자로 ScriptTest_2의 객체를 생성할 수 없습니다.");

        //  디버깅 모드로 실행후 함수 내부로 프로세스를 추적해볼것.
		CallStackTest();

		//	GameObject.Find
		//	-	씬에 있는 게임 오브젝트 중 특정 게임 오브젝트를 참조.
		GameObject gObjLight = GameObject.Find("Directional Light");

		//	GetComponent 
		//	-	게임 오브젝트에 연결된 다른 컴포넌트를 참조.
		_light = gObjLight.GetComponent<Light>();
    }
	//-----------------------------------------
    void Update()
    {
		if( Input.GetKeyUp(KeyCode.Space))
			//	enabled
			//	-	스크립트( 컴포넌트 )의 기능 On / Off.
			_light.enabled = !_light.enabled;
				
		if( Input.GetKeyUp(KeyCode.Return))
			//	GameObject.AddComponent
			//	-	해당 게임 오브젝트에 특정 스크립트( 컴포넌트 ) 추가.
			gameObject.AddComponent<ScriptTest_2>();
    }
	//-----------------------------------------

}//	public class ScriptTest_1 : MonoBehaviour
//================================================================