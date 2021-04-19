//============================================================
using UnityEngine;
//============================================================
public class LightColorTest : MonoBehaviour
{
    //-----------------------
    Light _myLight;
    public float _offset = 0.001f;
    //-----------------------
    private void Start() { _myLight = GetComponent<Light>(); }
    //-----------------------
    private void Update()
    {
        Color tmpColor = _myLight.color;
        tmpColor.r += _offset;
        _myLight.color = tmpColor;
    }
    //-----------------------
}
//============================================================