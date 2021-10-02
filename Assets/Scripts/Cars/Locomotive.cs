using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public Control coal; // The prefab for the coal minigame

    private ControlController controller;

    void Awake()
    {
        controller = (ControlController)FindObjectOfType<ControlController>();
    }


    // Start is called before the first frame update
    private void Start()
    {
        controller.addSpecificControl(coal);
        //controller.addRandomControl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
