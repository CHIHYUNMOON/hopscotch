using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private  Text _PlayerScore;
    public Text PlayerScore { get { return _PlayerScore; } set { _PlayerScore = value; } }
    //--------------------------------------------
    [SerializeField]
    private Text _AIScore;
    public Text AIScore { get { return _AIScore; } set { _AIScore = value; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
