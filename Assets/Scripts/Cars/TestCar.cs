using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCar : MonoBehaviour
{
    public Control gamePrefab;  // Assign your minigame prefab to this in the car's prefab

    private ControlController controller;

    public void Awake()
    {
        controller = FindObjectOfType<ControlController>();
    }

    public void Start()
    {
        controller.addSpecificControl(gamePrefab);
    }
}
