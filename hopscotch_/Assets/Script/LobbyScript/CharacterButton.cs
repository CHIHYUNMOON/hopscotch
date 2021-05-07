using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterButton : MonoBehaviour
{
    private SoundManager _soundManager;
    public UnityEvent _onMouseClick;

    private void Awake()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnMouseEnter()
    {
        _soundManager.PlayMouseEnter();
        this.GetComponent<Animator>().SetBool("isMouseON", true);
    }
    private void OnMouseExit() 
    {
        this.GetComponent<Animator>().SetBool("isMouseON", false);
        
    }

    private void OnMouseDown()
    {
        if (LobbyManager.Mode ==1 || LobbyManager.Mode ==2) {
            _soundManager.PlayMouseDown();
                }
    }
    private void OnMouseUp()
    {       
        if(LobbyManager.Mode == 1 || LobbyManager.Mode == 2)
        _onMouseClick.Invoke();
    }
}
  
