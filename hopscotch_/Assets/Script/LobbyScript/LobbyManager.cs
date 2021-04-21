using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public static bool StartPressed = false;
    GameObject TitleUI;
    GameObject BeforeGameStartUI;
    GameObject LobbyCamera;

    private void Awake()
    {
        TitleUI = GameObject.Find("Title");
        BeforeGameStartUI = GameObject.Find("BeforeGameStart");
        LobbyCamera = GameObject.Find("Main Camera");
        BeforeGameStartUI.SetActive(false); 
    }
    public void StartGame() 
    {
        StartPressed = true;
        TitleUI.SetActive(false);
        BeforeGameStartUI.SetActive(true);
        
    }
    public void SelectWoman()
    {
        if (StartPressed)
        {
            GameManager._PlayerCharacter = 1;
            SceneManager.LoadScene("MainStage");
        }
    }
    public void SelectBatboy()
    {
        if (StartPressed)
        {
            GameManager._PlayerCharacter = 2;
            SceneManager.LoadScene("MainStage");
        }
    }
    public void SelectMan()
    {
        if (StartPressed)
        {
            GameManager._PlayerCharacter = 3;
            SceneManager.LoadScene("MainStage");
        }
    }
    public void SelectPolice()
    {
        if (StartPressed)
        {
            GameManager._PlayerCharacter = 4;
            SceneManager.LoadScene("MainStage");
        }
    }
    public void ExitGame() {
        Application.Quit();
    }

    
}
