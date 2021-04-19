//===================================================================================
/*
    ------------------------------
    @   SetActive
    [ 참고 :  https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html ]
    ------------------------------
        -   원형
            -    public void SetActive(bool value);
               
        -   기능
            -   게임 오브젝트의 활성화 / 비활성화 상태 관리.
            -   활성화 / 비활성화 될때 OnEnable() / OnDisable() 를 호출함.

        
    ------------------------------
    @   activeSelf, activeInHierarchy
    [
        참고 :  https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html
                https://docs.unity3d.com/ScriptReference/GameObject-activeInHierarchy.html
    ]
        -   원형
            -   public bool activeInHierarchy;
            -   public bool activeSelf;

        -    기능
            -   게임 오브젝트의 활성화 / 비활성화 상태 정보 제공.
        
        -   차이점.
            ====================================================
                        |     activeSelf       |   activeInHierarchy
            -----------------------------------------------------
            차이점       |   로컬 정보          |  씬에서의 정보.
            =====================================================

*/
//===================================================================================
using UnityEngine;
//===================================================================================
public class SetActiveTest : MonoBehaviour
{
    //--------------------------------------
    public GameObject _parent;
    public GameObject _child;
    
    private void Update()
    {
        if( Input.GetKeyUp(KeyCode.Alpha1))
        {
            _parent.SetActive(!_parent.activeInHierarchy);
            Debug.Log("--------------------------------");
            Debug.Log(_parent.name + " activeInHierarchy :" + _parent.activeInHierarchy);
            Debug.Log(_parent.name + " activeSelf :" + _parent.activeSelf);
            Debug.Log("--------------------------------");
            Debug.Log(_child.name + " activeInHierarchy :" + _child.activeInHierarchy);
            Debug.Log(_child.name + " activeSelf :" + _child.activeSelf);
            Debug.Log("--------------------------------");

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _child.SetActive(!_child.activeSelf);
            Debug.Log("--------------------------------");
            Debug.Log(_parent.name + " activeInHierarchy :" + _parent.activeInHierarchy);
            Debug.Log(_parent.name + " activeSelf :" + _parent.activeSelf);
            Debug.Log("--------------------------------");
            Debug.Log(_child.name + " activeInHierarchy :" + _child.activeInHierarchy);
            Debug.Log(_child.name + " activeSelf :" + _child.activeSelf);
            Debug.Log("--------------------------------");
        }

        }

}
//===================================================================================