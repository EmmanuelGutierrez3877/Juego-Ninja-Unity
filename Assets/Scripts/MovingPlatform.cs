using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    private Transform WPA, WPB;
    private Transform destino;
    private Transform padre;
    private float _speed = 15f;
    

    public void Start()
    {
        padre = transform.parent;
        destino = WPB;

        StartCoroutine("Movimiento");
    }

    IEnumerator Movimiento()
    {
        //Debug.Log("Moviendo");
        while (padre.position != destino.position)
        {
            //Debug.Log("A");
            padre.position = Vector3.MoveTowards(padre.position, destino.position,Time.deltaTime * _speed);
            //other.transform.position = Vector3.MoveTowards(other.position, destino.position,Time.deltaTime * _speed);
            yield return new WaitForSeconds(.05f);
        }
        if (destino == WPA)
        {
            destino = WPB;
        }
        else if (destino == WPB)
        {
            destino = WPA;
        }
        StartCoroutine("Movimiento");
    }
}
