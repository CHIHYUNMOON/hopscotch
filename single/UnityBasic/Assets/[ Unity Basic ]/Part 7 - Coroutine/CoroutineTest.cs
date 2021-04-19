//==========================================================
/*
    -------------------------------
    @   코루틴( Coroutine )
    [ 
        참고  :     https://docs.unity3d.com/Manual/Coroutines.html
                    https://turtledove.tistory.com/94
                    https://blog.naver.com/wjdrudtn0225/222154879549
    ]
    -------------------------------
        -   코루틴
            -   일반적으로 함수는 병렬처리가 불가능.
                -   두개 이상의 함수를 동시에 처리 못함.
            -   코루틴은 실행을 중지하여 Unity에 제어권을 돌려주고,
                계속할 때는 다음 프레임에서 중지한 곳부터 실행을 계속할 수 있는 기능.
                ( 출처 : 유니티 메뉴얼 )
            -   마치 멀티스레드 처럼 두가지 이상의 기능이 동시에 처리되는 것처럼 작동.
                하지만, 코루틴은 단일 스레드 임.
        
        -   주요 용도
            -   파일 처리 또는 웹통신
                -   파일을 로딩하거나 웹 통신시 긴 작업시간이 필요한 경우.            
            -   이벤트성 Update
                -   일시적인 상황에서 실시간으로 처리해야하는 작업.
                    예) 게임 로딩 등.
            -   특정 시점에서 작업 처리.
                -   어떤 프로세스가 시작할때 일정 대기시간후 
                    작업을 처리하고 싶을때.
        
        -   주요 코루틴 사용 방식.
            -   코루틴 함수 정의
                형식) 
                        IEnumerator 코루틴함수명 ( 매개변수 )
                        {
                            .....
                            yield 구문.
                            .....
                        }

            -   코루틴 함수 작동 시작.
                형식)
                    StartCoroutine( 코루틴 함수명 );
            
            -   코루틴 함수 작동 정지.
                형식)
                    Coroutine _crtTmp = StartCoroutine( 코루틴 함수명 );

                    ....

                    StopCoroutine( _crtTmp );

        -   yield 구문.
            -   코루틴에 대한 제어권 양보 방식 설정.
            -   주요 구문
                -   yield return null
                    -   다음 프레임 까지 대기.
                    yield return new WaitForSeconds( float time )
                    -   지정한 시간( time 초 )까지 대기.
                    yield return new WaitForFixedUpate()
                    -   다음 물리 프레임 까지 대기.
                    yield return new WaitForEndOfFrame()
                    -   모든 렌더링 작업이 끝날때까지 대기.
                    yield break;
                    -   코루틴 강제 종료.
*/
//==========================================================
using UnityEngine;
using System.Collections;
//==========================================================
public class CoroutineTest : MonoBehaviour
{
    Coroutine _crtTmp;
    IEnumerator CrtTest() {
        while(true) {
            Vector3 pos = transform.position;
            pos.x += Time.deltaTime * 5;
            transform.position = pos;
            yield return null;
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        _crtTmp = StartCoroutine( CrtTest() );
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
            StopCoroutine( _crtTmp );
        
    }
}
//==========================================================
/*
    Q ) 코루틴을 이용하여 간단한 타이머를 만들어 봅니다.
        
        예)
            남은 시간 : 5
            남은 시간 : 4
            남은 시간 : 3
            남은 시간 : 2
            남은 시간 : 1
            남은 시간 : 0
            땡!!!
*/
//==========================================================