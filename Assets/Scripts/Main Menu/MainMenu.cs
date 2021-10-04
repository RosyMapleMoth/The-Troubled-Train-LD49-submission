using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    public void PlayGame()
    {

    }

    public void CreditsToggle()
    {
        if(creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
        }
        else
        {
            creditsPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
