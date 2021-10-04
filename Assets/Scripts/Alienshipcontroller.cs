using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienshipcontroller : MonoBehaviour
{
    public int left = 0;
    public int right = 15;

    public ParticleSystem laser;
    
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        laser = transform.parent.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Side is which side the alien is one 0 is left and 1 is right
    /// </summary>
    /// <param name="side"></param>
    public void alienEnter(int side)
    {
        switch (side)
        {
            case 0: gameObject.transform.position = new Vector3(left , gameObject.transform.position.y, gameObject.transform.position.z); break;
            case 1: gameObject.transform.position = new Vector3(right, gameObject.transform.position.y, gameObject.transform.position.z); break;
            default: break;
        }

        anim.SetTrigger("alien enter");
    }

    public void alienExit()
    {
        laser.Play();
        anim.SetTrigger("alien leve");
    }

}
