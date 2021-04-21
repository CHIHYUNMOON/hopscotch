using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterButton : MonoBehaviour
{
    
    public UnityEvent _onMouseClick;
    
    private void OnMouseEnter()
    {
        this.GetComponent<Animator>().SetBool("isMouseON", true);
    }
    private void OnMouseExit() 
    {
        this.GetComponent<Animator>().SetBool("isMouseON", false);
    }

    private void OnMouseUp()
    {
        
        if(LobbyManager.StartPressed)
        _onMouseClick.Invoke();
    }
}
  
