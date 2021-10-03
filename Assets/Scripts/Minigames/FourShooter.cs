using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourShooter : MonoBehaviour
{
    public GameObject bulletOne;
    public GameObject bulletTwo;
    public GameObject bulletThree;
    public GameObject bulletFour;

    private const float SHOOT_TIMER_BASE = 3f;
    public float shoot_timer = SHOOT_TIMER_BASE;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform == bulletOne.transform)
                {
                    
                }
                if (hit.transform == bulletTwo.transform)
                {
                    
                }
                if(hit.transform == bulletThree.transform)
                {
                    
                }
                if (hit.transform == bulletFour.transform)
                {
                   
                }
            }
        }
    }
}
