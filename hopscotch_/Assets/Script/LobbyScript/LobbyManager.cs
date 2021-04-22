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
        StartCoroutine(CameraMove());
        
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
    public void ReturnToTitle() {
        StartPressed = false;
        TitleUI.SetActive(true);
        BeforeGameStartUI.SetActive(false);
        StartCoroutine(CameraMove());
    }
    public void ExitGame() {
        Application.Quit();
    }

    IEnumerator CameraMove() 
    {
        if (StartPressed)
        {
            while (LobbyCamera.transform.position.z <= -7.0f)
            {
                LobbyCamera.transform.position += Vector3.forward * 0.1f;
                yield return null;
            }
            yield return null;
        }
        else if (!StartPressed)
        {
            while (LobbyCamera.transform.position.z >= -10.0f) {
                LobbyCamera.transform.position -= Vector3.forward * 0.1f;
                yield return null;
            }
        }


        StopCoroutine(CameraMove());
    }
    
}
