using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Scene : MonoBehaviour {

    public void CargarEscenaScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void CargarEscenaInstrucciones()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void QuitGame()
    {
        Debug.Log("saliste");
        Application.Quit();
    }
}
