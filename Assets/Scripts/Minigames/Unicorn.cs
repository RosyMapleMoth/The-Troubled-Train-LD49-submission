using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unicorn : MonoBehaviour
{
    public Text warningLabel;

    public GameObject earthButton;
    public GameObject airButton;
    public GameObject fireButton;
    public GameObject waterButton;

    public float castingDelay = 5f;

    public AudioSource earthNoise;
    public AudioSource airNoise;
    public AudioSource fireNoise;
    public AudioSource waterNoise;

    public AudioSource wizardNoise;
    public AudioSource successNoise;

    private UnicornCar car;

    private float nextSpell;
    private float spellCastTime;

    private bool castingSpell = false;

    private int incomingSpellElementCode; // 0: Earth 1: Air 2: Fire 3: Water
    private int activeShieldCode;

    private void Awake()
    {
        foreach(UnicornCar uni in FindObjectsOfType<UnicornCar>())
        {
            if(!uni.HasGame())
            {
                car = uni;
                car.SetGame(this);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        nextSpell = Time.time + Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform == earthButton.transform)
                {
                    PressEarth();
                }
                else if(hit.transform == airButton.transform)
                {
                    PressAir();
                }
                else if(hit.transform == fireButton.transform)
                {
                    PressFire();
                }
                else if(hit.transform == waterButton.transform)
                {
                    PressWater();
                }
            }
        }

        if(!castingSpell && Time.time >= nextSpell)
        {
            wizardNoise.Play();

            castingSpell = true;
            CalcNextTime();

            spellCastTime = Time.time;

            incomingSpellElementCode = Random.Range(0, 4);

            switch(incomingSpellElementCode)
            {
                case 0:
                    WarnEarth();
                    break;
                case 1:
                    WarnAir();
                    break;
                case 2:
                    WarnFire();
                    break;
                case 3:
                    WarnWater();
                    break;
                default:
                    Debug.LogError("Invalid spell code on unicorn car!");
                    WarnWater();
                    incomingSpellElementCode = 3;
                    break;
            }
        }
        
        if(castingSpell && Time.time >= spellCastTime + castingDelay)
        {
            castingSpell = false;
            ResolveSpell();
        }
    }

    private void WarnEarth()
    {
        warningLabel.text = "E";
    }

    private void WarnAir()
    {
        warningLabel.text = "A";
    }

    private void WarnFire()
    {
        warningLabel.text = "F";
    }

    private void WarnWater()
    {
        warningLabel.text = "W";
    }

    private void ClearWarning()
    {
        warningLabel.text = "";
    }

    private void PressEarth()
    {
        earthNoise.Play();
        car.EarthShield();
        activeShieldCode = 0;
    }

    private void PressAir()
    {
        airNoise.Play();
        car.AirShield();
        activeShieldCode = 1;
    }

    private void PressFire()
    {
        fireNoise.Play();
        car.FireShield();
        activeShieldCode = 2;
    }

    private void PressWater()
    {
        waterNoise.Play();
        car.WaterShield();
        activeShieldCode = 3;
    }

    private void ResolveSpell()
    {
        bool success = false;

        nextSpell = Time.time + Random.Range(3f, 5f);
        ClearWarning();

        switch(incomingSpellElementCode)
        {
            case 0:
                if(activeShieldCode == 3)
                {
                    success = true;
                }
                break;
            case 1:
                if(activeShieldCode == 0)
                {
                    success = true;
                }
                break;
            case 2:
                if(activeShieldCode == 1)
                {
                    success = true;
                }
                break;
            case 3:
                if(activeShieldCode == 2)
                {
                    success = true;
                }
                break;
        }

        if(success)
        {
            successNoise.Play();
        }
    }

    private void CalcNextTime()
    {
        nextSpell = Time.time;
    }
}
