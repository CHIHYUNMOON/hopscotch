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

    public void Restart()
    {
        SceneManager.LoadScene("MainStage");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Lobby");
    }
    private void Awake()
    {
        EndGameUI = GameObject.Find("GameEndUI");
        MenuUI = GameObject.Find("MenuUI");
        EndGameUI.SetActive(false);
        MenuUI.SetActive(false);
        
    }
    // Start is called before the first frame update
    public void OpenMenu() {
        MenuUI.SetActive(true);
    }

    // Update is called once per frame
   
}
