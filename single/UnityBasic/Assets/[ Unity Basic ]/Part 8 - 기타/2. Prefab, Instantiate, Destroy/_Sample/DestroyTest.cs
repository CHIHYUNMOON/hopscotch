//======================================================
/*
    ---------------------------------
    @   Destroy
    [ 참고 : https://docs.unity3d.com/ScriptReference/Object.Destroy.html ]
        -   기능
            -   게임 오브젝트나 컴포넌트 제거.

        -   원형
            -   public static void Destroy(Object obj, float t = 0.0F)
                -   obj :   제거할 대상.
                    t   :   대상을 제거하기까지 대기 시간.
    ---------------------------------
 
*/
//======================================================
using UnityEngine;
//======================================================
public class DestroyTest : MonoBehaviour
{
    //--------------------------------
    public float _destroyTime = 1f;
    //--------------------------------
    void Start() { DestroySelf( _destroyTime ); }
    //--------------------------------
    void DestroySelf(float time) { Destroy(gameObject, _destroyTime ); }
    //--------------------------------

}// public class DestroyTest : MonoBehaviour
//======================================================