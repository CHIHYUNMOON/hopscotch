using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LobbyManager : MonoBehaviour
{
    public static bool StartPressed = false;
    GameObject TitleUI;
    GameObject _1PlayerMode;
    GameObject _2PlayerMode;
    GameObject ModeSelectUI;
    GameObject LobbyCamera;
    SoundManager soundManager;
    public static int Mode;
   
    private void Awake()
    {
        StartPressed = false;
        Mode = 0;
        TitleUI = GameObject.Find("Title");
        _1PlayerMode = GameObject.Find("1Player");
        _2PlayerMode = GameObject.Find("2Player");
        ModeSelectUI = GameObject.Find("ModeSelect");
        LobbyCamera = GameObject.Find("Main Camera");
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _1PlayerMode.SetActive(false);
        _2PlayerMode.SetActive(false);
        ModeSelectUI.SetActive(false);
    }
    public void StartGame() 
    {
        soundManager.PlayMouseDown();
        
        TitleUI.SetActive(false);
        ModeSelectUI.SetActive(true);               
    }
    public void SelectWoman()
    {
        if (Mode == 1)
        {
            GameManager._Player1Character = 1;
            SceneManager.LoadScene("MainStage");
        }
        else if (Mode == 2) 
        {
            if (GameManager._Player1Character == 0)
            {
                GameManager._Player1Character = 1;
            }
            else if (GameManager._Player2Character == 0) 
            {
                GameManager._Player2Character = 1;
                SceneManager.LoadScene("MainStage");
            }
            
        }
    }
    public void SelectBatboy()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 2;
            SceneManager.LoadScene("MainStage");
        }
        else if (Mode == 2)
        {
            if (GameManager._Player1Character == 0)
            {
                GameManager._Player1Character = 2;
            }
            else if (GameManager._Player2Character == 0)
            {
                GameManager._Player2Character = 2;
                SceneManager.LoadScene("MainStage");
            }
        }
    }
    public void SelectMan()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 3;
            SceneManager.LoadScene("MainStage");
        }
        else if (Mode == 2)
        {
            if (GameManager._Player1Character == 0)
            {
                GameManager._Player1Character = 3;
            }
            else if (GameManager._Player2Character == 0)
            {
                GameManager._Player2Character = 3;
                SceneManager.LoadScene("MainStage");
            }
        }
    }
    public void SelectPolice()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 4;
            SceneManager.LoadScene("MainStage");
        }
        else if (Mode == 2)
        {
            if (GameManager._Player1Character == 0)
            {
                GameManager._Player1Character = 4;
            }
            else if (GameManager._Player2Character == 0)
            {
                GameManager._Player2Character = 4;
                SceneManager.LoadScene("MainStage");
            }
        }
    }
    public void ReturnToTitle() 
    {
        soundManager.PlayMouseDown();
        StartPressed = false;
        Mode = 0;
        TitleUI.SetActive(true);
        _1PlayerMode.SetActive(false);
        _2PlayerMode.SetActive(false);
        ModeSelectUI.SetActive(false);
        StartCoroutine(CameraMove());
    }
    public void ExitGame() {
        soundManager.PlayMouseDown();
        Invoke("SealQuit", 0.2f);
    }

    public void SoloMode() {
        Mode = 1;
        soundManager.PlayMouseDown();
        ModeSelectUI.SetActive(false);
        _1PlayerMode.SetActive(true);
        StartPressed = true;
        StartCoroutine(CameraMove());
    }

    public void DuoMode() 
    {
        Mode = 2;
        soundManager.PlayMouseDown();
        ModeSelectUI.SetActive(false);
        _2PlayerMode.SetActive(true);
        
        StartCoroutine(CameraMove());
    }
    private void SealQuit()
    {
        Application.Quit();
    }
    IEnumerator CameraMove() 
    {
        if (Mode==1 || Mode==2)
        {
            while (LobbyCamera.transform.position.z <= -7.0f)
            {
                LobbyCamera.transform.position += Vector3.forward * 0.1f;
                yield return null;
            }
            yield return null;
        }
        else 
        {
            while (LobbyCamera.transform.position.z >= -10.0f) {
                LobbyCamera.transform.position -= Vector3.forward * 0.1f;
                yield return null;
            }
        }
        StopCoroutine(CameraMove());
    }
    
}
