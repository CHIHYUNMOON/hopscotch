using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private  Text _PlayerScore;
    public Text PlayerScore { get { return _PlayerScore; } set { _PlayerScore = value; } }
    //--------------------------------------------
    [SerializeField]
    private Text _AIScore;
    public Text AIScore { get { return _AIScore; } set { _AIScore = value; } }

    public GameObject EndGameUI;
    public GameObject MenuUI;
    private SoundManager soundManager;

    private void MainStageLoader() {
        SceneManager.LoadScene("MainStage");
    }
    private void LobbyLoader() {
        SceneManager.LoadScene("Lobby");
    }
    public void Restart()
    {
        soundManager.PlayMouseDown();
       
        Invoke("MainStageLoader", 0.1f);
    }
    public void ToMainMenu()
    {
        soundManager.PlayMouseDown();
        
        Invoke("LobbyLoader", 0.1f);

    }
    private void Awake()
    {
        EndGameUI = GameObject.Find("GameEndUI");
        MenuUI = GameObject.Find("MenuUI");
        EndGameUI.SetActive(false);
        MenuUI.SetActive(false);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
   
    public void OpenMenu() {
        MenuUI.SetActive(true);
        soundManager.PlayMouseDown();
    }
    public void CloseMenu() {
        MenuUI.SetActive(false);
        soundManager.PlayMouseDown();
    }
   
}
