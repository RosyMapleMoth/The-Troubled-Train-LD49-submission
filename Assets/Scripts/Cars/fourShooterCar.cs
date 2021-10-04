using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourShooterCar : MonoBehaviour
{
    public Control gamePrefab;  // Assign your minigame prefab to this in the car's prefab

    private ControlController controller;

    void Awake()
    {
        controller = FindObjectOfType<ControlController>();
    }

    void Start()
    {
        controller.addSpecificControl(gamePrefab);
    }
}
