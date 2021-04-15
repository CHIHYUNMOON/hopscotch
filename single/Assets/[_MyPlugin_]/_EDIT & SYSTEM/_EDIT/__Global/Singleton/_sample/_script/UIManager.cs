//==================================================
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//==================================================
public class UIManager : MonoBehaviour
{
    //------------------------
    SingletonTest       _singletonTest;
    SingletonMonoTest   _singletonMonoTest;
    List<ITest> _iList;
    //------------------------
    private void Awake()
    {
        _singletonTest      = SingletonTest.Instance;
        _singletonMonoTest  = SingletonMonoTest.Instance;
        _iList = new List<ITest>();
        _iList.Add(_singletonTest);
        _iList.Add(_singletonMonoTest);
    }
    //------------------------
    public void OnBttnRandom()
    {
        foreach (ITest iTmp in _iList)
            iTmp.SetRandom();
    }
    //------------------------
    public void OnBttnPrintInConsole()
    {
        foreach (ITest iTmp in _iList)
        {
            Debug.Log(iTmp.ToString());
            iTmp.Print();
        }            
    }
    //------------------------
    public void OnBttnLoadScene(string scene)   { SceneManager.LoadScene(scene); }
    //------------------------

}// public class UIManager : MonoBehaviour
//==================================================