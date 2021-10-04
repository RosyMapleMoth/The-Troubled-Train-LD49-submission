using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : TestCar
{

    private ControlController controller;



    void Awake()
    {
        base.Awake();
        // add car specific awake here
    }

    void Start()
    {
        base.Start();
        // add car specific start up here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
