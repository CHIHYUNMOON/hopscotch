//==========================================================================
/*
    -------------------------------
    @   Time.deltaTime
    [
        참고  :   https://docs.unity3d.com/kr/530/ScriptReference/Time-deltaTime.html
    ]
    -------------------------------
        -   기능.
            -   이전 프레임이 완료되기까지 걸린 시간.
                -   이전 프레임과 현재 프레임 사이의 시간 간격을 반환.
            -   단위는 초( sec ).

        -   활용.
            -   컴퓨터간 성능 보간.
                -   동일한 게임을 처리하는데 
                    컴퓨터 A는 10프레임, 컴퓨터 B는 20프레임이라 가정하자.
                    
                    1프레임당 1m를 이동하는 총알을 설계했을때 동시에 총을 쏘는 경우,
                    A는 1초후 10m, B는 20m를 이동한다.

                    두 컴퓨터가 온라인으로 대전을 한다면 B 컴퓨터 유저가 유리하다.

                    이때 두 컴퓨터의 Time.deltaTime은 각각 평균 1/10초, 1/20초가 된다.
                    Time.deltaTime을 곱해주면 1프레임당 각각 0.1m, 0.05m를 이동하여
                    1초후에는 동일한 위치에 있게된다.

                    물론 A컴이 상대적으로 뚝뚝 끊겨보일수 있지만 속도는 동일해 졌다

            -   프레임 단위 이동이 아닌 속도단위 이동.
                -   1초당 몇 m로 이동하도록 설정 가능.
                -   속도 = 거리 / 시간.
                    거리 = 속도 * 시간.

*/
//==========================================================================
using UnityEngine;
//==========================================================================
public class TimeDeltaTest : MonoBehaviour
{
    public bool _bySpeed = false;
    public float _speed = 10f;
    // Update is called once per frame
    void Update()
    {
        if(_bySpeed)
        {
            //  속도의 단위로 이동.
            float deltaTime = Time.deltaTime;
            Debug.Log(" deltaTime : " + deltaTime);
            transform.Translate(deltaTime * _speed, 0, 0);            
        }else
            //  프레임 단위로 이동.
            transform.Translate(_speed, 0, 0);
    }
}
//==========================================================================
                                                                            