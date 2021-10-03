using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCar : MonoBehaviour
{
    public Control gamePrefab;  // Assign your minigame prefab to this in the car's prefab

    public GameObject gun;

    public AudioSource lazerNoise;

    private ControlController controller;

    private Lazer myGame;

    void Awake()
    {
        controller = FindObjectOfType<ControlController>();
    }

    void Start()
    {
        controller.addSpecificControl(gamePrefab);
    }

    void Update()
    {
        gun.transform.rotation = Quaternion.Euler(-45f, ((myGame.GetLeftOrRight() - 0.5f) * -90f), 0f);
    }

    public bool HasGame()
    {
        return (myGame != null);
    }

    public void SetGame(Lazer game)
    {
        myGame = game;
    }

    public void ShootAlien()
    {
        lazerNoise.Play();
    }
}
