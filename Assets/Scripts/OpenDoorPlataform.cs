using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorPlataform : MonoBehaviour {


    [SerializeField]
    private Transform door;
    private Renderer _MatD;
    private Renderer _Mat;
    private Color _color;
    private AudioAdmin audio;

    void Start()
    {
        audio = GameObject.FindObjectOfType<AudioAdmin>();
        _Mat = transform.parent.GetComponent<Renderer>();
        _MatD = door.GetComponent<Renderer>();
        _color = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
        );
        _Mat.material.color = _color;
        _MatD.material.color = _color;
    }
    public void OnTriggerEnter(Collider other)
    {
        door.gameObject.SetActive(false);
        audio.PlayAudio("door");
    }

}
