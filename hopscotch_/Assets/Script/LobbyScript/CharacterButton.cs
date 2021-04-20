using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterButton : MonoBehaviour
{
    
    public UnityEvent _onMouseClick;

    private void OnMouseUp()
    {
        Debug.Log("Click");
        if(LobbyManager.StartPressed)
        _onMouseClick.Invoke();
    }
}
  
