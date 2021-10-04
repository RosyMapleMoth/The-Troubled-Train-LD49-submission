using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour
{


    public GameObject gameOver;

    public bool Broken = false;
    public int ySize;
    public int xSize;

    public ParticleSystem BrokenSmoke;

    public GameObject ControlBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void loseMiniGame()
    {
        Broken = true;
        BrokenSmoke.Play();
        gameOver.SetActive(true);
        GameUI.Instance.LoseMiniGame();
    }
}
