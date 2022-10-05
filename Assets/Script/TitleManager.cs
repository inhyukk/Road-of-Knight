using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public EnergyBar loadBar;
    int energy = 0;

    IEnumerator Loading()
    {
        loadBar.gameObject.SetActive(true);

        while(energy < 85)
        {
            energy += 1;
            loadBar.SetValueCurrent((int)energy);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0.5f);

        energy = 100;
        loadBar.SetValueCurrent(energy);
        
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void TouchtoStart()
    {
        StartCoroutine(Loading());
    }
}
