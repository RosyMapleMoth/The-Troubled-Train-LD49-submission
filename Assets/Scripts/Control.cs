using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour
{


    public GameObject gameOver;
    public int ySize;
    public int xSize;
    public GameObject ControlBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MiniGameOver()
    {
        gameOver.SetActive(true);
        GameUI.Instance
    }



}
