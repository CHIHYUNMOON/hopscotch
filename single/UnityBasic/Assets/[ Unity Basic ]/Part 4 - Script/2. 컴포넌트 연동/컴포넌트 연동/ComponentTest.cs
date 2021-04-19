//============================================================
/*
    GetComponent 계열 함수.
    -   게임 오브젝트에 연결된 특정 컴포넌트의 참조값을 반환.
    -   사용
        T tmp = GetComponent<T>();

    Find 계열 함수.
    -   씬에 등록된 게임 오브젝트중 특정 게임 오브젝트의 참조값 반환.
    -   사용
        GamoObject tmp = GameObject.Find(검색 기준);
        

*/
//============================================================
using UnityEngine;
//============================================================
public class ComponentTest : MonoBehaviour
{
    //-----------------------
    Transform _myTransf;
    public float _offset = 0.0001f;
    public GameObject _camGObj;
    //-----------------------
    void Start()
    {
        //  1-1)  GetComponent 사용 예.
        _myTransf = GetComponent<Transform>();
        
        //  1-2)
        //  _myTransf = gameObject.GetComponent<Transform>();

        //  2-1)  일부 컴포넌트는 유니티에서 키워드로 지원.
        //  _myTransf = transform;

        //  2-2)
        //  _myTransf = gameObject.transform;


    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 curPos = _myTransf.position;        
        curPos.x += _offset;        
        _myTransf.position = curPos;

        if ( _camGObj == null)                          //  _camGObj에 값이 할당되어 있지 않다면..
            _camGObj = GameObject.Find("Main Camera");  //  메인 카메라 게임 오브젝트를 찾아서 할당.
                                                        //  -   좋지 않은 방식.

        Vector3 camPos = _camGObj.transform.position;
        camPos.y -= _offset;
        _camGObj.transform.position = camPos;

    }
}
//============================================================
/*
    테스트
    -   조명의 색이 조금씩 바뀌도록 합니다.
*/
//============================================================