using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    public GameObject button;
    public Control myController;
    public AudioSource coalSound;
    public AudioSource engineDyingSound;
    public AudioSource overheatSound;
    private GroundCycler cycler;
    private float heat = 5f;
    public float decay = 0.5f;
    public float fuel = 2f;
    public float slowFactor = 2f;
    public float speedFactor = 2f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        cycler = (GroundCycler)FindObjectOfType(typeof(GroundCycler));
        myController = gameObject.GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myController.Broken)
        {
            workingUpdate();
        }
        else
        {
            brokenUpdate();
        }
    }


    /// <summary>
    ///  TODO if you want any logical while broken run it in here
    /// </summary>
    public void brokenUpdate()
    {

    }


    /// <summary>
    /// All Logic for normal function happens here 
    /// </summary>
    public void workingUpdate()
    {
        
        heat -= decay * Time.deltaTime;

        anim.SetFloat("Hand Position", (heat / 10f));

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform == button.transform)
                {
                    anim.SetTrigger("Button Press");

                    heat += fuel;

                    coalSound.Play();
                }
            }
        }

        if (heat <= 0f)
        {
            heat = 0f;
            Die();

            cycler.speed -= slowFactor * Time.deltaTime;
            if(cycler.speed < 0)
            {
                cycler.speed = 0; // No reversing
            }
        }
        else if (heat >= 8f)
        {
            Overheat();

            if (heat > 10f)
            {
                heat = 10f;
            }

            cycler.speed += speedFactor * Time.deltaTime;
        }
    }


    private void Die()
    {
        if (!engineDyingSound.isPlaying)
        {
            engineDyingSound.Play();
        }
    }

    private void Overheat()
    {
        if(!overheatSound.isPlaying)
        {
            overheatSound.Play();
        }
    }
}
