using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    public Canvas MenuCanvas;

    void Start()
    {
        MenuCanvas.enabled = false;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}