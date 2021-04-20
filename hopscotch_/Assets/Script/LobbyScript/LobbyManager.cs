using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public static bool StartPressed = false;
    public void StartGame() 
    {
        StartPressed = true;
        
    }
    public void SelectWoman()
    {
        GameManager._PlayerCharacter = 1;
        SceneManager.LoadScene("MainStage");
    }
    public void SelectBatboy()
    {
        GameManager._PlayerCharacter = 2;
        SceneManager.LoadScene("MainStage");
    }
    public void SelectMan()
    {
        GameManager._PlayerCharacter = 3;
        SceneManager.LoadScene("MainStage");
    }
    public void SelectPolice()
    {
        GameManager._PlayerCharacter = 4;
        SceneManager.LoadScene("MainStage");
    }
    public void GotoCharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    
}
