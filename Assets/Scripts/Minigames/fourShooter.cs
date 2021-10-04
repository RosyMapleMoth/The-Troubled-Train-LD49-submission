using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fourShooter : MonoBehaviour
{

    public GameObject[] Bullets;
    Animator anim;


    private bool FailedGame = false;

    public int shotsFired; 


    private const float BANDIT_TIMER_RESET = 5f;
    private float BanditTimer = BANDIT_TIMER_RESET;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BanditTimer -= Time.deltaTime;

        if (BanditTimer <= 0)
        {
            anim.SetTrigger("Shoot bullet");
            anim.SetTrigger("Trigger Smoke Effect");
            shotsFired++;
            BanditTimer = BANDIT_TIMER_RESET;

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
