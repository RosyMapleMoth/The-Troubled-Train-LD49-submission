using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GroundCycler groundCycler;

    public Text speedText;
    public Text distanceText;

    public GameObject pauseScreen;

    private float distance = 0f;

    private const int possableMistakes = 5;
    private int Mistakes = 0;


    private static GameUI _instance;

    public static GameUI Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameUI>();
            }

            return _instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }

        distance += (groundCycler.speed * Time.deltaTime);

        speedText.text = ("Speed: " + KPHConvert(groundCycler.speed).ToString("F2") + " KPH");
        distanceText.text = ("Distance: " + distance.ToString("F2") + " M");
    }

    public float KPHConvert(float input)
    {
        return (input * 3.6f);
    }

    public void PauseToggle()
    {
        if(pauseScreen.activeSelf)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoseMiniGame()
    {
        Mistakes++; 
    }

}
