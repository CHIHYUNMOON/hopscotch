//=================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//=================================================================
interface ITest
{
    void SetRandom();
    void Print();
}
//=================================================================
public class SingletonTest : Singleton<SingletonTest>, ITest
{
    //-----------------------
    public int _dataA = 100;
    public int _dataB = 100;
    public int _dataC = 100;
    //-----------------------
    public void SetRandom()
    {
        _dataA = Random.Range(10, 100);
        _dataB = Random.Range(10, 100);
        _dataC = Random.Range(10, 100);

    }// public void SetRandom()
    //-----------------------
    public void Print() { Debug.Log("_dataA : " + _dataA + "___" + "_dataB : " + _dataB + "___" + "_dataC : " + _dataC); }        
    //-----------------------

}// public class SingletonDataTest : SingletonDef<SingletonDataTest>
//=================================================================
public class SingletonMonoTest : SingletonMono<SingletonMonoTest>, ITest
{
    //-----------------------------
    public int _dataA = 10;
    public int _dataB = 20;
    //-----------------------------
    public void SetRandom()
    {
        _dataA = Random.Range(10, 100);
        _dataB = Random.Range(10, 100);

    }// public void SetRandom()
    //-----------------------------
    public void Print() { print("_dataA : " + _dataA + "   " + "_dataB : " + _dataB); }
    //-----------------------------

}// public class SingletonTest : SingletonGOB<SingletonTest>
//=================================================================