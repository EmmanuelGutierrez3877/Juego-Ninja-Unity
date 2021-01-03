using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Object_Script : MonoBehaviour {

    // Use this for initialization
    private float _XR, _YR, _ZR;
    
    void Start () {
        _XR = Random.Range(0, 30);
        _YR = Random.Range(0, 30);
        _ZR = Random.Range(0, 30);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(_XR,_YR,_ZR) * Time.deltaTime);
	}
}
