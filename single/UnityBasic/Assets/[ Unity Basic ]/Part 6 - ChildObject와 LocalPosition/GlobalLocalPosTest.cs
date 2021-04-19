//======================================================================
/*
    ------------------------------------
    부모 자식 관계 설정.
    [
        참고 :    https://docs.unity3d.com/ScriptReference/Transform-parent.html 
                  https://programmers.co.kr/learn/courses/1/lessons/583
                  https://programmers.co.kr/learn/courses/1/lessons/665
                  https://openwiki.kr/unity/class-transform#%EB%B6%80%EB%AA%A8%EC%9E%90%EC%8B%9D%EA%B4%80%EA%B3%84%EC%84%A4%EC%A0%95_%ED%8C%A8%EC%96%B4%EB%9F%B0%ED%8C%85_parenting
    ]
    ------------------------------------
    
    -   패어런팅( Parenting )
        -   계층구조적인 논리에서 하나의 게임 오브젝트가 다른 게임 오브젝트보다
            상위 계층인 상태로 만드는 것.
        -   하이어라키에서 어떤 게임 오브젝트를 드래그하여 다른 게임 오브젝트에
            오버랩 하면 적용됨.
      
    -   특징
        -   부모는 하나밖에 가질수 없지만 자식은 여러개 가질 수 있음.

        -   자식은 부모의 트랜스폼 정보에 상대적임.

        -   인스펙터상의 트랜스폼 정보는 로컬 정보.
            -   부모에 상대적인 정보.

        -   최상위 부모의 인스펙터상의 트랜스폼 정보는 로컬 정보이지만
            부모가 없으므로 월드 정보와 동일.
            -   월드가 부모인 셈.
            -   일반적으로 게임오브젝트 생성시 트랜스폼을 초기화해서 사용할 것을 권장.
                -   패어런팅시 좌표가 꼬이는 것 방지.
            -   참고 : http://blog.naver.com/forest62590/100191635029
*/
//======================================================================
using UnityEngine;

public class GlobalLocalPosTest : MonoBehaviour
{
    Transform _myTrsf;
    Vector3 _originPos;
    Vector3 _originLocalPos;
    // Start is called before the first frame update
    void Start()
    {
        _myTrsf = GetComponent<Transform>();
        _originPos = _myTrsf.position;
        _originLocalPos = _myTrsf.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        /*
            ========================================================================
                            |   공통점             |          부모
            ------------------------------------------------------------------------
            월드 좌표       |   부모의 원점을      |    월드 공간, 씬.
            ----------------    기준으로 설정된    |--------------------------------
            로컬 좌표       |   좌표 정보.         |    하이어라키 계층 구조에서
                            |                      |    상위 오브젝트.
            ========================================================================
         */

        //  월드 좌표상에서 변환.
        Vector3 tmpPos = _myTrsf.position;
        if( Input.GetKeyUp(KeyCode.Alpha1))
        {
            tmpPos.x = 8;
            _myTrsf.position = tmpPos;
        }

        //  로컬 좌표상에서 변환.
        tmpPos = _myTrsf.localPosition;
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            tmpPos.x = 8;
            _myTrsf.localPosition = tmpPos;
        }

    }
}
//======================================================================
/*
	Q )
		패어런팅을 이용하여 부모 오브젝트를 중심으로하여 
		키보드 좌우 키를 입력하면 Z축으로 회전하는 오브젝트를 만듭니다.

		팁   ) Input.GetAxis( 키보드 입력 처리 ), Quaternion.Euler( 회전 처리 )를 검색하여 응용해보세요.	
        [ 참고 : https://m.blog.naver.com/dj3630/221447943453
                
                짐벌락 
                https://www.youtube.com/watch?v=zc8b2Jo7mno&feature=emb_logo&ab_channel=GuerrillaCG ]
*/
