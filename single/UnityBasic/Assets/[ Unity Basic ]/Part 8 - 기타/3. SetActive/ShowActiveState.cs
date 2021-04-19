using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowActiveState : MonoBehaviour
{
    //--------------------------------------
    bool IsActive(GameObject gobj) { return gobj.activeInHierarchy; }
    void ShowActiv(GameObject gobj) { Debug.Log( gobj.name + " In the Scene : " + IsActive(gobj) ); }
    bool IsActiveLocal(GameObject gobj) { return gobj.activeSelf; }
    void ShowActivLocal(GameObject gobj) { Debug.Log(gobj.name + " In the Local : " + IsActiveLocal(gobj) ); }
    //--------------------------------------
    void Start()
    {
        Debug.Log("-- Start --");
        ShowActiv(gameObject);
        ShowActivLocal(gameObject);
    }
    private void OnEnable()
    {
        Debug.Log("-- OnEnable --");
        ShowActiv(gameObject);
        ShowActivLocal(gameObject);
    }
    private void OnDisable()
    {
        Debug.Log("-- OnDisable --");
        ShowActiv(gameObject);
        ShowActivLocal(gameObject);
    }
}
