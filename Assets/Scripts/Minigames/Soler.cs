using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soler : MonoBehaviour
{
    private Animator anim;
    public Control myController;
    public GameObject sunTracker;
    public GameObject PlayerPos;
    public GameObject leftControl;
    public GameObject rightControl;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myController = gameObject.GetComponent<Control>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///  TODO if you want any logical while broken run it in here
    /// </summary>
    public void brokenUpdate()
    {

    }


    public void workingUpdate()
    {
        
    }
}
