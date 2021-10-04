using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject infoPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("TrainMoveTest");
    }

    public void CreditsToggle()
    {
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
        }

        if (creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
        }
        else
        {
            creditsPanel.SetActive(true);
        }
    }

    public void InfoToggle()
    {
        if (creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
        }

        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
