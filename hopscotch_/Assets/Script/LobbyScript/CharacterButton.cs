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
        if (LobbyManager.StartPressed) {
            _soundManager.PlayMouseDown();
                }
    }
    private void OnMouseUp()
    {       
        if(LobbyManager.StartPressed)
        _onMouseClick.Invoke();
    }
}
  
