using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    public void RestartBtn()
    {
        SceneManager.LoadScene("Loading", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}