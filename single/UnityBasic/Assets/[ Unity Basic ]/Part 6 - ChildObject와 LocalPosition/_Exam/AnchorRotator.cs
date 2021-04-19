using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorRotator : MonoBehaviour
{
	public float _rotateSpeed;
    
    void Update()
    {
		float rotVal = -Input.GetAxis("Horizontal") * _rotateSpeed;

		Quaternion curRot = transform.rotation;
		curRot = Quaternion.Euler(0,0,rotVal);
		transform.rotation = curRot;
    }
}
