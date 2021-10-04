using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourShooter : MonoBehaviour
{

    public GameObject[] Bullets;
    private Animator anim;
    public Control myController;
    private bool FailedGame = false;
    public int shotsFired;

    public AudioSource gunshotNoise;
    public AudioSource reloadNoise;


    private const float BANDIT_TIMER_RESET = 5f;
    private float BanditTimer = BANDIT_TIMER_RESET;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        BanditTimer -= Time.deltaTime;

        if (BanditTimer <= 0)
        {
            anim.SetTrigger("Shoot bullet");
            anim.SetTrigger("Trigger Smoke Effect");
            gunshotNoise.Play();
            shotsFired++;
            BanditTimer = BANDIT_TIMER_RESET;
            if (shotsFired > 5)
            {
                myController.loseMiniGame();
            }

        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject bullet in Bullets)
                {
                    if(hit.transform == bullet.transform && ! bullet.GetComponent<MeshRenderer>().enabled)
                    {
                        if (!anim.IsInTransition(0))
                        {
                            anim.SetTrigger("Reload Bullet");
                            reloadNoise.Play();
                            shotsFired--;
                        }
                    }
                }
            }
        }
    }


    public void GameOver()
    {
        FailedGame = true;
    }
}
