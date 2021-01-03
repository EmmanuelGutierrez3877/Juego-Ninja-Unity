using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset_Scene_Script : MonoBehaviour {

    // Use this for initialization
    private Button _restartButton;

    void Start () {
        _restartButton = GetComponent<Button>();
        _restartButton.image.gameObject.SetActive(false);
        _restartButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void ShowButton()
    {
        _restartButton.image.gameObject.SetActive(true);
    }
}
