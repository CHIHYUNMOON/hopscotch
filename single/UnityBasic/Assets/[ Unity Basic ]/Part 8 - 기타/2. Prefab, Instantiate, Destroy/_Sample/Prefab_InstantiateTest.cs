//==============================================================
/*
    ---------------------------------
    @   프리팹
    [ 참고 :    https://game-secret.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B03D-Tip-Prefab%EC%9D%B4%EB%9E%80 ]
    ---------------------------------
        -   정의
            -   건축용어로써 공장에서 부품 미리 만들어놓고
                현장에서 조립하는 건축공법의 총칭( 출처 : 네이버 사전 )

            -   유니티에 적용.
                -   게임오브젝트를 미리 만들어놓고 필요할때마다 불러다 쓰는 기법.

        -   프리팹 특징
            -   똑같은 객체 생성.
            -   무한히 생성.
            -   객체마다 속성을 다르게 설정.

        -   프리팹 생성.
            -   하이어라키에 등록된 게임오브젝트 선택 후 프로젝트 창으로 드래그.

        -   프리팹을 씬에 배치
            -   방법 1)   프로젝트창의 프리팹 선택 후 씬 또는 하이어라키로 드래그.
            -   방법 2)   스크립트에서 Instantiate 함수 호출.

        -   프리팹 수정 적용.
            -   방법 1)   프로젝트창의 프리팹 직접 수정.
            -   방법 2)   씬에 등록된 게임 오브젝트( by 프리팹 )의 속성 수정
                            ->  인스펙터 창 > Overrides 선택.
                            ->  Apply All 버튼 클릭.
                                * Revert All    :   수정전 상태로 복귀.
                          
        
        -   프리팹 활용.
            1)  똑같은 몬스터나 아이템들을 여러개 씬에 생성.
            2)  똑같은 몬스터라 할지라도 들고있는 무기나 속성등을 다르게 적용.
            3)  주인공이 총을 쏘는데 총알은 무한히 나간다.
                총을 쏠때마다 똑같은 총알이 가상공간 안에 생성되어야 함.
            4)  게임 내에서 건물을 지을때 유저가 건물을 구매하면
                구매한 건물이 유저의 영토에 생성.
                건물이 똑같고, 조건에 따라 여러번 구매할 수도 있으며,
                같은 건물이면 거의 동일한 속성을 지니지만,
                위치나 색상 등은 조건에 따라 조금씩 다를 수 있음.
                (예) 크래시 오브 클랜, 룰더스카이 등.

    ---------------------------------
    @   Instantiate
    [ 참고 :    https://docs.unity3d.com/ScriptReference/Object.Instantiate.html ]
    ---------------------------------
        -   기능
            -   원본 게임 오브젝트를 복제.

        -   원형
            -   public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
                외 다수.
                -   original    :   복제하고자 하는 게임 오브젝트 원형.
                    position    :   배치하고자 하는 위치.
                    rotation    :   배치할때 적용할 회전값.
                    반환값       :   복제된 게임 오브젝트의 참조값.
        
*/
//==============================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==============================================================
public class Prefab_InstantiateTest : MonoBehaviour
{
    //--------------------------------
    public GameObject _prefab;
    public float _destroyMinTime = 1f;
    public float _destroyMaxTime = 3f;
    //--------------------------------
    void Update()
    {
        if( Input.GetMouseButtonUp(0) ) {
            Vector3 randPos = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f));
            GameObject tmpGObj = Instantiate(_prefab, randPos, Quaternion.identity);
            //  복제한 게임오브젝트의 컴포넌트 접근.
            DestroyTest tmpDestroy = tmpGObj.GetComponent<DestroyTest>();
            if( tmpDestroy != null )
                tmpDestroy._destroyTime = Random.Range(_destroyMinTime, _destroyMaxTime);
		}
    }
    //--------------------------------

}// public class Prefab_Instantiate_DestroyTest : MonoBehaviour
 //==============================================================
/*
    Q ) 마우스를 누르고 있으면 일정시간마다 총알이 나가는 대포를 만듭니다.    
*/
//==============================================================