using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public EnergyBar loadBar;
    float energy = 0;
    
    private void LoadBar()
    {
        while (energy < 100)
        {
            energy++;
            loadBar.SetValueCurrent((int)energy);
        }
        if(energy >= 100)
        {
            Invoke("Loading", 0.5f);
            energy = 0;
        }
    }

    public void TouchtoStart()
    {
        loadBar.gameObject.SetActive(true);
        LoadBar();
    }

    void Loading()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
