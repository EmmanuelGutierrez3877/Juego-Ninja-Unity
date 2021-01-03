using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlataform : MonoBehaviour {

    [SerializeField]
    private GameObject objeto;
    private GameObject padre;
    private Vector3 _StartPosision;
    private bool _detect;
    [SerializeField]
    private float time;

    void Start()
    {    
        padre = transform.parent.gameObject;
        _StartPosision = padre.transform.position;
        _detect = true;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (_detect == true)
        {
            Debug.Log("Fall");
            _detect = false;
            StartCoroutine("Fall");
        }
        
    }

    IEnumerator Fall()
    {
        Debug.Log(_StartPosision);
        for (float ft = time; ft >= -0.1; ft -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        padre.GetComponent<Rigidbody>().useGravity = true;
        for (float ft = 3.0f; ft >= -0.1; ft -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        //Debug.Log("fin");

        padre.GetComponent<Rigidbody>().useGravity = false;
        GameObject InstantiatedGameObject = Instantiate(objeto, _StartPosision, gameObject.transform.rotation);
        padre.gameObject.SetActive(false);
        padre.transform.position = _StartPosision;
    }

    

}
