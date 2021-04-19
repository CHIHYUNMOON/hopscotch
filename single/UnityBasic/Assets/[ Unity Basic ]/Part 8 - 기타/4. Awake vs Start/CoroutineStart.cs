//======================================================================
//  참고 : https://daebalstudio.tistory.com/entry/Coroutine-완벽하게-알기
//======================================================================
using System.Collections;
using UnityEngine;
//======================================================================
public class CoroutineStart : MonoBehaviour
{
    IEnumerator Start()
    {
        int count = 0;
        while( true ) {
            yield return new WaitForSeconds(1f);
            ++count;
            Debug.Log("경과시간 : " + count);
            if( count == 5)
                break;
        }
        yield return StartCoroutine(WaitAndPrint(3f));
        Debug.Log("Done. " + Time.time);
    }
    
    IEnumerator WaitAndPrint(float time)
    {
        yield return new WaitForSeconds(time);
 
        // waitTime 뒤에 실행됩니다.
        Debug.Log("WaitAndPrint. " + Time.time);
    }



}
//======================================================================