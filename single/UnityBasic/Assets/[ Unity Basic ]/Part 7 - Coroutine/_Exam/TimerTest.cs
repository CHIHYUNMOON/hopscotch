//===============================================================
using System.Collections;
using UnityEngine;
//===============================================================
public class TimerTest : MonoBehaviour
{
    //---------------------------
    public int _destTime;
    //---------------------------
    void Start() { StartCoroutine(CrtTimer()); }
    //---------------------------
    IEnumerator CrtTimer()
    {
        while (true)
        {            
            Debug.Log("남은 시간 : " + _destTime);
            
            if (_destTime <= 0)
            {
                Debug.Log("땡~!!!");
                yield break;
            }

            --_destTime;
            yield return new WaitForSeconds(1);

        }// while (true)

    }// IEnumerator CrtTimer()
    //---------------------------

}// public class TimerTest : MonoBehaviour
 //===============================================================