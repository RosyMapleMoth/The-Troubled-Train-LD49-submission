using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("TrainMoveTest");
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
