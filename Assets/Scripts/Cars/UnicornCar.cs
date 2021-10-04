using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornCar : MonoBehaviour
{
    public GameObject wizard;

    public GameObject shield;

    public Material earthShield;
    public Material airShield;
    public Material fireShield;
    public Material waterShield;

    public AudioSource shieldNoise;

    private Unicorn uniGame;

    void Awake()
    {
        shield.SetActive(false);
    }

    public void EarthShield()
    {
        shieldNoise.Play();

        shield.SetActive(true);
        shield.GetComponent<Renderer>().material = earthShield;
    }

    public void AirShield()
    {
        shieldNoise.Play();

        shield.SetActive(true);
        shield.GetComponent<Renderer>().material = airShield;
    }

    public void FireShield()
    {
        shieldNoise.Play();

        shield.SetActive(true);
        shield.GetComponent<Renderer>().material = fireShield;
    }

    public void WaterShield()
    {
        shieldNoise.Play();

        shield.SetActive(true);
        shield.GetComponent<Renderer>().material = waterShield;
    }

    public bool HasGame()
    {
        return !(uniGame == null);
    }

    public void SetGame(Unicorn game)
    {
        uniGame = game;
    }
}
