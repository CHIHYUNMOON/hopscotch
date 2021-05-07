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
    private bool _isPlayer1Select;
    [SerializeField]
    GameObject SelectFrame1Prefab;
    [SerializeField]
    GameObject SelectFrame2Prefab;
    GameObject SelectFrame1;
    GameObject SelectFrame2;
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
        _isPlayer1Select = false;
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
            SelectFrame1 =Instantiate(SelectFrame1Prefab);
            SelectFrame1.transform.position = new Vector3(-1, 0, 0);
            StartCoroutine(MainStageLoader());
        }
        else if (Mode == 2) 
        {
            if (!_isPlayer1Select)
            {
                GameManager._Player1Character = 1;
                SelectFrame1 = Instantiate(SelectFrame1Prefab);
                SelectFrame1.transform.position = new Vector3(-1, 0, 0);
                _isPlayer1Select = true;
            }
            else 
            {
                GameManager._Player2Character = 1;
                SelectFrame2 = Instantiate(SelectFrame2Prefab);
                SelectFrame2.transform.position = new Vector3(-1, 0, 0);
                StartCoroutine(MainStageLoader());
            }
            
        }
    }
    public void SelectBatboy()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 2;
            SelectFrame1 = Instantiate(SelectFrame1Prefab);
            SelectFrame1.transform.position = new Vector3(1, 0, 0);
            StartCoroutine(MainStageLoader());
        }
        else if (Mode == 2)
        {
            if (!_isPlayer1Select)
            {
                GameManager._Player1Character = 2;
                SelectFrame1 = Instantiate(SelectFrame1Prefab);
                SelectFrame1.transform.position = new Vector3(1, 0, 0);
                _isPlayer1Select = true;
            }
            else
            {
                GameManager._Player2Character = 2;
                SelectFrame2 = Instantiate(SelectFrame2Prefab);
                SelectFrame2.transform.position = new Vector3(1, 0, 0);
                StartCoroutine(MainStageLoader());
            }
        }
    }
    public void SelectMan()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 3;
            
            SelectFrame1 = Instantiate(SelectFrame1Prefab);
            SelectFrame1.transform.position = new Vector3(-3, 0, 0);
            StartCoroutine(MainStageLoader());

        }
        else if (Mode == 2)
        {
            if (!_isPlayer1Select)
            {
                GameManager._Player1Character = 3;
                SelectFrame1 = Instantiate(SelectFrame1Prefab);
                SelectFrame1.transform.position = new Vector3(-3, 0, 0);
                _isPlayer1Select = true;
            }
            else 
            {
                GameManager._Player2Character = 3;
                SelectFrame2 = Instantiate(SelectFrame2Prefab);
                SelectFrame2.transform.position = new Vector3(-3, 0, 0);
                StartCoroutine(MainStageLoader());
            }
        }
    }
    public void SelectPolice()
    {
        if (Mode==1)
        {
            GameManager._Player1Character = 4;
            SelectFrame1 = Instantiate(SelectFrame1Prefab);
            SelectFrame1.transform.position = new Vector3(3, 0, 0);
            StartCoroutine(MainStageLoader());
        }
        else if (Mode == 2)
        {
            if (!_isPlayer1Select)
            {
                
                GameManager._Player1Character = 4;
                SelectFrame1 = Instantiate(SelectFrame1Prefab);
                SelectFrame1.transform.position = new Vector3(3, 0, 0);
                _isPlayer1Select = true;
            }
            else 
            {
                GameManager._Player2Character = 4;
                SelectFrame2 = Instantiate(SelectFrame2Prefab);
                SelectFrame2.transform.position = new Vector3(3, 0, 0);
                StartCoroutine(MainStageLoader());
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

    private IEnumerator MainStageLoader() {
        Light light = GameObject.Find("Directional Light").GetComponent<Light>();
        while (light.intensity > 0.1f) {
            light.intensity -= 0.01f;
            yield return null;
        }
        SceneManager.LoadScene("MainStage");
        yield return null;
    }

}
