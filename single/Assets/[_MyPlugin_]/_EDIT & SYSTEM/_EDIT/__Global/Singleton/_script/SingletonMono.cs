//===========================================================
//	jackie	싱글턴 템플릿.	160510.
//===========================================================
using System;
using UnityEngine;
//===========================================================
public class Singleton<T> where T : class, new()	//	T는 참조형, 기본 생성자가 있어야함. 
													//	[ 참고 : //	https://qzqz.tistory.com/214 ]
{
	//--------------------------
	//	싱글턴 패턴의 인터페이스.
	public static T Instance
	{
		get;
		private set;

	}//	public static T Instance
	//--------------------------
	//	생성자가 private -> 외부에서 new 로 생성 못함.
	static Singleton()
	{
		if(Singleton<T>.Instance == null )
			Singleton<T>.Instance = new T();

	}//	static Singleton()
	//--------------------------
	public virtual void Clear() { Singleton<T>.Instance = null; }
	//--------------------------

}//	public class Singleton<T> where try : class, new()
//===========================================================
public abstract class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T> //	T는 SingletonMono<T>의 자식 클래스.
{
	//------------------------------------------
	private static T m_Instance = null;
	//------------------------------------------
	public static T Instance
    {
		get
		{
			//	Instance 처음 호출시..
			if ( m_Instance == null )
			{				
				m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;

				//	이미 만들어진 인스턴스가 없다면..
				if ( m_Instance == null )
				{
					//	새로 만든다.
					//	게임오브젝트가 생성되는 시점에서 Awake 함수가 호출됨.
					//	Start는 한 프레임 후 호출 됨.
					m_Instance = new GameObject("SingleTon Of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
				
					//	에러 체크.
					if( m_Instance == null )
						Debug.LogError("Problem during the creation of " + typeof(T).ToString());
				
				}//	if( m_Instance == null )

				//	초기화 작업 진행.
				m_Instance.Init();
			
			}//	if( m_Instance == null )
			
			return m_Instance;
		
		}//	get
	
	}//	public static T instance
	//------------------------------------------
	private void Awake()
	{
		//	게임 오브젝트 생성시점에는 m_Instance 값이 null.
		if ( m_Instance == null )
		{
			//	this( 클래스의 객체 참조값 )로 할당.
			m_Instance = this as T;

			//	씬이 전환되어도 해당 게임오브젝트 파괴되지 않도록 설정.
			DontDestroyOnLoad( gameObject );
		
		}//	if( m_Instance == null )
	
	}//	private void Awake()
	//------------------------------------------
	//	초기화 작업 처리 인터페이스.
	protected virtual void Init()       {}
	//------------------------------------------
	//	프로젝트 종료시 처리.
	private void OnApplicationQuit()    { m_Instance = null; }
	//------------------------------------------
	
}//	public abstract class SingletonGOB<T> : MonoBehaviour where T : SingletonGOB<T>
//===========================================================