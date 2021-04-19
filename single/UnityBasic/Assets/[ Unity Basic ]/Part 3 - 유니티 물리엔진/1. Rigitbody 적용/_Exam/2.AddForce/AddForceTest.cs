//====================================================
using UnityEngine;
//====================================================
public class AddForceTest : MonoBehaviour
{
	//--------------------------
	public float _pow = 1.0f;
    Rigidbody rb;
	//--------------------------
    void Start() { rb = GetComponent<Rigidbody>(); }
	//--------------------------
    void Update()
    {
		if( Input.GetKeyUp(KeyCode.Space)) {
			
			Debug.Log("transform.forward : " + transform.forward);
			rb.AddForce(transform.forward * _pow);
		}
    }
	//--------------------------
}
//====================================================