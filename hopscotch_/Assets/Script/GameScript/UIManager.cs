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

    [SerializeField]
    private Button _restartBT;
    public Button RestartBT { get { return _restartBT; } set { _restartBT = value; } }
    [SerializeField]
    private Button _toMainMenuBT;
    public Button ToMainMenuBT { get { return _toMainMenuBT; } set { _toMainMenuBT = value; } }


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
        _restartBT.gameObject.SetActive(false);
        _toMainMenuBT.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
}
